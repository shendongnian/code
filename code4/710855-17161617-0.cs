    //http://localhost/Movies/Create/1 -> invokes Movies controller and Create action.
    
     public static void RegisterRoutes(RouteCollection routes)
        {
             routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
             routes.MapRoute(
                 name: "MoviesCreate",
                 url: "Movies/{Movies}/Create/{id}",
                 defaults: new { controller = "Movies", action = "Create", id = UrlParameter.Optional }
                 );    
    //http://Movies/JCameron/Titanic/12 -> invokes Movies controller and Index action.
    
             routes.MapRoute(
                 name: "MoviesHome",
                 url: "Movies/{Director}/{Movie}/{id}",
                 defaults: new { controller = "Movies", action = "Index", id = UrlParameter.Optional, Director = UrlParameter.Optional, Movie = UrlParameter.Optional }
                 );
    
    }
