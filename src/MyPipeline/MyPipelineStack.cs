using Amazon.CDK;
using Amazon.CDK.Pipelines;

namespace MyPipeline
{
    public class MyPipelineStack : Stack
    {
        internal MyPipelineStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var pipeline = new CodePipeline(this, "pipeline", new CodePipelineProps
            {
                PipelineName = "MyPipeline",
                Synth = new ShellStep("Synth", new ShellStepProps
                {
                    Input = CodePipelineSource.GitHub("ruskindantra/my-pipeline", "main"),
                    Commands = new[]
                    {
                        // "npm ci", 
                        // "npm run build", 
                        // "npx cdk synth"
                        "npm install -g aws-cdk",
                        "cdk --version",
                        "npx cdk synth"
                    }
                })
            });
        }
    }
}
