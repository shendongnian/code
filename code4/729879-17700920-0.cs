    using Newtonsoft.Json.Serialization;
    
    protected void Application_Start()
    {
         config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
