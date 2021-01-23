    //Global.asax.cs
    protected void Application_Start()
    {
        LocatorInitializationHandler.Initialize();
    
        AreaRegistration.RegisterAllAreas();
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    }
