    private BuildParameters CreateBuildParameters()
    {
        var projectCollection = new ProjectCollection();
        var buildLogger = new FileLogger { Verbosity = LoggerVerbosity.Detailed, Parameters = "logfile=" + DebuggerLogFileName };
        var buildParameters = new BuildParameters(projectCollection) { Loggers = new List<ILogger>() { buildLogger } };
        return buildParameters;
    }
    private BuildRequestData CreateBuildRequest()
    {
        var globalProperties = new Dictionary<string, string>();
        var buildRequest = new BuildRequestData(FolderPath + ProjectFileName, globalProperties, null,
                                                new string[] { "Build" }, null, BuildRequestDataFlags.ReplaceExistingProjectInstance);
        return buildRequest;
    }
