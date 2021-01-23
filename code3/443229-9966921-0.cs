    void Application_Start(object sender, EventArgs e) 
    {
        RouteTable.Routes.Add(
           new ServiceRoute("Authorization", 
                            new ServiceHostFactory(), typeof(Authenticator)));
        RouteTable.Routes.Add(
           new ServiceRoute("Miscellaneous", 
                            new ServiceHostFactory(), typeof(Misc)));
    }
