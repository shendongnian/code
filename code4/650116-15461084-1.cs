    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        WebApiConfig.Register(GlobalConfiguration.Configuration);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        AuthConfig.RegisterAuth();
        AutoMapperConfig.RegisterConfig();
        Database.SetInitializer(new ContextInitializer());
        using (var context = new Context())
        {
            context.Database.Initialize(false);
        }
        if (!WebSecurity.Initialized)
        {
            WebSecurity.InitializeDatabaseConnection(
                connectionStringName: "DefaultConnection", 
                userTableName: "User", 
                userIdColumn: "Id", 
                userNameColumn: "Email", 
                autoCreateTables: false);
        }
    }
