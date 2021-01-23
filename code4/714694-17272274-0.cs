    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
          "Default", // Route name
          "{controller}/{action}/{id}", // URL with 
          new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );
    }
This means when you call the website root with no parameters, it uses the default values - in this case home/index.
