    public static void RegisterRoutes(RouteCollection routes)
    {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.MapRoute(
             "HomeIndex", // Name
             "",
             new { lang = "EN", controller = "Home", action = "Index" } // Defaults);
         // Catch all route
         routes.MapRoute(
         "Default", // Name
         "{lang}/{controller}" + System.Configuration.ConfigurationManager.AppSettings["extension"] + "/{action}/{*values}",  // URL - ["extension"] being .aspx for IIS 6
         new { lang = "EN", controller = "Content", action = "Index" } // Defaults);
     }
