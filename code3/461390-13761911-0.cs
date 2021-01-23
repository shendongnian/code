    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = 
            Newtonsoft.Json.PreserveReferencesHandling.None;
        }
     }
