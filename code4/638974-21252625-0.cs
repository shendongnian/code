    public static void Register(HttpConfiguration config)
    {
      config.MapHttpAttributeRoutes();
    
      // There can be multiple exception loggers.
      // (By default, no exception loggers are registered.)
      config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
    
      // There must be exactly one exception handler.
      // (There is a default one that may be replaced.)
      config.Services.Replace(typeof(IExceptionHandler), new GenericTextExceptionHandler());
    }
