        public void Configuration(IAppBuilder app)
        {      
           //auth config, service registration, etc      
           var config = new HttpConfiguration();
           config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
           //other config settings, dependency injection/resolver settings, etc
           app.UseWebApi(config);
    }
