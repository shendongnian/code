    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
      routes.MapRoute(
        "Default",
        "{controller}.mvc/{action}/{id}",
        new { action = "Index", id = "" }
      );
    
      routes.MapRoute(
        "Root",
        "",
        new { controller = "Home", action = "Index", id = "" }
      );
    }
