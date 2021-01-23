    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    public static void RegisterRoutes(RouteCollection routes)
    {
        //Make sure to add this BEFORE any other routes.
        routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));
        
        //Site
        routes.MapPageRoute("", "{address}", "~/{address}.aspx");
        routes.MapPageRoute("", "{address}/{resource}", "~/{address}/{resource}.aspx");
    }
