    //Global.asax.cs
    protected void Application_Start()
    {
        LocatorInitializationHandler.Inizialize();
    
        AreaRegistration.RegisterAllAreas();
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    }
