    ....
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //using "pretty urls" - ordering your routes matter.
        routes.MapPageRoute("theWebForm", "legacy", "~/somedirectory/default.aspx");
        routes.MapRoute(
            "Default", 
            "{controller}/{action}/{id}", 
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
    }
