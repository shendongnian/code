    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");            
            
            // some routes ...
            routes.MapRoute(
                name: "GetSoftware",
                url: "Area/GetSoftware/{AreaID}",
                defaults: new { controller = "Area", action = "GetSoftware", AreaID = UrlParameter.Optional }
            );
            // some other routes ...
            // default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );  
 
