    protected void Application_Start()
    {
        GlobalHost.HubPipeline.AddModule(new MyHubPipelineModule());
        //...
        RouteTable.Routes.MapHubs();
    }
