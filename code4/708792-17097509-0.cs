    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}/{id1}/", // URL with parameters
            new { controller = "Home", 
                  action     = "Index", 
                  id         =  UrlParameter.Optional, 
                  id1        =  UrlParameter.Optional 
                } // Parameter defaults
        );
    
        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}", // URL with parameters
            new { controller = "Home", action = "Index" } // Parameter defaults
        );
    }
