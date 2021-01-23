    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.Add("BikeSaleRoute", new Route
        (
           "bikes/sale", 
           new CustomRouteHandler("~/Contoso/Products/Details.aspx")
        ));
    }
