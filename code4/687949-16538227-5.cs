    protected void Application_Start()
    {
        RouteTable.Routes.Add(
            new Route(
                "eventAggregation/events", 
                new MyHandlerProvider()
            )
        );
    }
