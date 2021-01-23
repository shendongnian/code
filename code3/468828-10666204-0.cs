    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
    
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    
        var context = new KCSoccerDataContext();
        var initializeDomain = new CreateDatabaseIfNotExists<KCSoccerDataContext>();
        var initializeMigrations = new MigrateDatabaseToLatestVersion<KCSoccerDataContext, Core.Migrations.Configuration>();
    
        initializeDomain.InitializeDatabase(context);
        initializeMigrations.InitializeDatabase(context);
    
    }
