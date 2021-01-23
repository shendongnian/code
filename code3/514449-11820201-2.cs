    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "visitors", // Route name
            "visitor/{i}/{v}", // URL with parameters
            new
            {
                controller = "Visitor", action = "Test",
                i = UrlParameter.Optional, v = UrlParameter.Optional
            }
        );
        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
