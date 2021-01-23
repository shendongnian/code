    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapRoute(
            "UpcomingKeyDates", // Route name
            "KeyDates.mvc/{sortBy}/Page/{page}", // URL with parameters
            new { controller = "Home", action = "Index" }, // Parameter defaults
            new { page = @"\d+" } // Note I have constrained the page so it has to be an integer...
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
