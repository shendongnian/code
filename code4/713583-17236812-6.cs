    //Global.asax.cs
    protected void Application_Start()
    {
        MyInitializationHandler.Inizialize();
    
        AreaRegistration.RegisterAllAreas();
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    }
