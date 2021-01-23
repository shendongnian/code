    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        GlobalConfiguration.Configuration.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });
        
        RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        RouteTable.Routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { 
                controller = "Home", 
                action = "Index", 
                id = UrlParameter.Optional });
    }
