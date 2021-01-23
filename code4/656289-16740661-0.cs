    FileLogger fl = new FileLogger() { Parameters = @"logfile=somepath" };
    Dictionary<string, string> GlobalProperty = new Dictionary<string, string>();
    GlobalProperty.Add("Configuration", "Debug");
    GlobalProperty.Add("Platform", "x86");
    BuildRequestData BuildRequest = new BuildRequestData(slnPath, GlobalProperty, null, new string[] { "Build" }, null);
    BuildParameters bp = new BuildParameters();
    bp.Loggers = new List<Microsoft.Build.Framework.ILogger> { fl }.AsEnumerable();
    BuildResult buildResult = BuildManager.DefaultBuildManager.Build(bp, BuildRequest);
