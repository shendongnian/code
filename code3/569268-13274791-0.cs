    protected void Application_Start()
    {
        HttpConfiguration config = GlobalConfiguration.Configuration;
        config.Formatters.JsonFormatter.SerializerSettings.Formatting =
            Newtonsoft.Json.Formatting.Indented;
    }
