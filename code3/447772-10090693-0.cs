    protected void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes.Add(new ServiceRoute("", new WebServiceHostFactory(), 
                                               typeof(YourService)));
    }
