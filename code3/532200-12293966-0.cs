    protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas(); //1. registers areas
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes); //2. only after that register root routes
        }
