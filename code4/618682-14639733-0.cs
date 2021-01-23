      public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           //Make sure this route is the first one to be added
            routes.MapRoute(
               "ErrorHandler",
               "ErrorHandler/{action}/{errMsg}",
               new { controller = "ErrorHandler", action = "Index", errMsg=UrlParameter.Optional}
               );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
          
        }
