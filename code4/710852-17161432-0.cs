    public static void RegisterRoutes(RouteCollection routes)
    {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         routes.MapRoute(
             name: "Default2",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Movies", action = "Create", id = UrlParameter.Optional }
             );    
         routes.MapRoute(
             name: "Default",
             url: "{Director}/{Movie}/{id}",
             defaults: new { controller = "Movies", action = "Index", id = UrlParameter.Optional, Director = UrlParameter.Optional, Movie = UrlParameter.Optional }
             );
    
            
    }
