    var enableLogging =
        Convert.ToBoolean(ConfigurationManager.AppSettings["EnableLogging"]);
    container.RegisterInitializer<Logger>(logger =>
    {
        logger.EnableLogging = enableLogging;
    });
