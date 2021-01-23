    // Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.Configure<MvcJsonOptions>(config =>
        {
            config.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });
    }
