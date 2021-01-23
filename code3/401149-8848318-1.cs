    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapRoute(
            "UpcomingKeyDates", // Route name
            "KeyDates.mvc/{sortBy}/Page/{page}", // URL with parameters
            new { controller = "Home", action = "Index" } // Parameter defaults
        );
    
        routes.MapRoute(
           "MyDefaultRoute", // Your special default which inserts .mvc into every route
           "{controller}.mvc/{action}/{id}", // URL with parameters
           new { controller = "Home", action = "Index", id=UrlParameter.Optional, sortBy = "EventDate" } // Parameter defaults
        );
    
        routes.MapRoute(
           "Default", // Real default route. Matches any other route not already matched, including ""
           "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id=UrlParameter.Optional, sortBy = "EventDate" } // Parameter defaults
        );
    }
