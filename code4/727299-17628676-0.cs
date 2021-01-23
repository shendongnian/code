    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathInfo}");//add this line 
    
        routes.MapPageRoute("",
            "{Name}",
            "~/Membersite.aspx");
    }
