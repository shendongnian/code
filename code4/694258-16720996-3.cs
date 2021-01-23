    protected override void Initialize(HttpControllerContext context)
    {
      base.Initialize(context);
    
      var jSettings = context.Configuration.Formatters.JsonFormatter.SerializerSettings;
      jSettings.ContractResolver = MyResolver;
    }
