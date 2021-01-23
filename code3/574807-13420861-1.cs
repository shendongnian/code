     public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(
                "Export",                                                            // Route name
                "Export/{action}/{table}",                                       // URL with parameters
                new { controller = "Export", action = "AsExcel", table = "" }  // Parameter defaults
            );
           
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }
