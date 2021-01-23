    protected void Application_Start()
    {
        RegisterRoutes(RouteTable.Routes);
        DefaultModelBinder.ResourceClassKey = "Messages";
    }
