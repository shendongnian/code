    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
    
        var nhConfig = new Configuration().Configure();
        SessionFactory = nhConfig.BuildSessionFactory();
    }
