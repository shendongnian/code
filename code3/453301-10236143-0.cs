    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "TrackingChannels", 
            "Dis/TrackingChannels/{action}", 
            new { controller = "TrackingChannels", action = "Index" }
        );
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
