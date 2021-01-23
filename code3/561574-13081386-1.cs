    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
        ControllerBuilder.Current.SetControllerFactory(new NInjectControllerFactory());  
    }
