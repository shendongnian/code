    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("RemoveASPx", "{*file}", "~/{file}.aspx");
    }
    
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
