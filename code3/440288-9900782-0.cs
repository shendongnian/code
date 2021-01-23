    int id = 123123;
    Dictionary<int, LogWriter> loggers = new Dictionary<int, LogWriter>();
    ConfigurationSourceBuilder builder = new ConfigurationSourceBuilder();
    builder.ConfigureLogging()
            .WithOptions
                .DoNotRevertImpersonation()
            .SpecialSources.LoggingErrorsAndWarningsCategory.SendTo.FlatFile("Flat File Listener").ToFile(@"trace.log")
            .LogToCategoryNamed("General")
                .WithOptions.SetAsDefaultCategory()
                .SendTo.FlatFile("AppSpecificFlatFile" + id)
                .ToFile("logging" + id + ".log")       
                ;
    DictionaryConfigurationSource configSource = new DictionaryConfigurationSource();
    builder.UpdateConfigurationWithReplace(configSource);
    coreExtension = new EnterpriseLibraryCoreExtension(configSource);
    IUnityContainer container = new UnityContainer();
    container.AddExtension(coreExtension);
    var logger = container.Resolve<LogWriter>();
    loggers[id] = logger;
