    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapRoute(
          "qwert", // Route name
          "{type}/{controller}/{action}/{id}", // URL with parameters
          new { controller = "Login", action = "Index", type = "", id = UrlParameter.Optional } // Parameter defaults
        );
    }
