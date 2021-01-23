    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Search",
                routeTemplate: "api/search/{minDate}/{maxDate}/{summaryOnly}",
                defaults: new { 
                    summaryOnly = RouteParameter.Optional,  
                    controller = "SomeThing", 
                    action = "search" 
                }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
