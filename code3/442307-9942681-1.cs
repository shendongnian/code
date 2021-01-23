    public class Compiler
        {
            private static string locationOfMSBuilldEXE = "";
            public static void Build(string msbuildFileName)
            {
                ConsoleLogger logger = new ConsoleLogger(LoggerVerbosity.Normal);
                BuildManager manager = BuildManager.DefaultBuildManager;
                
                ProjectInstance projectInstance = new ProjectInstance(msbuildFileName);
                var result = manager.Build(
                    new BuildParameters() 
                    {
                        DetailedSummary = true,
                        Loggers = new List<ILogger>(){logger}
                    }, 
                    new BuildRequestData(projectInstance, new string[] { "Build" }));
                var buildResult = result.ResultsByTarget["Build"];
                var buildResultItems = buildResult.Items;
                
                string s = "";
            }
        }
