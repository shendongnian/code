    using Microsoft.Build.Framework;
    using Microsoft.Build.Execution;
    public bool UpdateSchema(string db) {
        var props = new Dictionary<string, string> {
            { "UpdateDatabase", "True" },
            { "PublishScriptFileName", "schema-update.sql" },
            { "SqlPublishProfilePath", "path/to/publish.xml") }
        };
        
        var projPath = "path/to/database.sqlproj";
        var result = BuildManager.DefaultBuildManager.Build(
            new BuildParameters { Loggers = new[] { new ConsoleLogger() } },
            new BuildRequestData(new ProjectInstance(projPath, props, null), new[] { "Publish" }));
        if (result.OverallResult == BuildResultCode.Failure) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Schema update failed!");
            Console.ResetColor();
        }
    }
    private class ConsoleLogger : ILogger
    {
        public void Initialize(IEventSource eventSource) {
            eventSource.ErrorRaised += (sender, e) => {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            };
            eventSource.MessageRaised += (sender, e) => {
                if (e.Importance != MessageImportance.Low)
                    Console.WriteLine(e.Message);
            };
        }
        public void Shutdown() { }
        public LoggerVerbosity Verbosity { get; set; }
        public string Parameters { get; set; }
    }
