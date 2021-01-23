    protected void Application_Start()
    {
        var container = new Container();
        var dbConnectionFactory = new OrmLiteConnectionFactory("Server=localhost;Port=5432;User Id=dms; Password=dms; Database=dms", PostgreSqlDialect.Provider);
        container.Register<IDbConnectionFactory>(dbConnectionFactory);
        container.RegisterAutoWiredAs<AppUserRepository, IAppUserRepository>();
        DependencyResolver.SetResolver(new FunqDependencyResolver(container));
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
    }
