    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        //should be called before RegisterRoutes
        CustomRouteConstraint.SetControllerNamespace("********.Controllers");
        WebApiConfig.Register(GlobalConfiguration.Configuration);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);            
    }
