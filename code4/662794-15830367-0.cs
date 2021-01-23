    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { 
                    controller = "Home", 
                    action = "Index", 
                    id = UrlParameter.Optional 
            }, // Parameter defaults
            new string[] {
                // namespaces in which to find controllers for this route
                "MySolution.MyControllersLib1.Helpers", 
                "MySolution.MyControllersLib2.Helpers",
                "MySolution.MyControllersLib3.Helpers" 
            } 
        );
    }
