    IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
    if (configurationSource.GetSection(LoggingSettings.SectionName) != null)
    Logger.SetLogWriter(new LogWriterFactory(configurationSource).Create());
    ExceptionPolicy.SetExceptionManager(new ExceptionPolicyFactory(configurationSource).CreateManager());
