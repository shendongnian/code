    using System.Web.Http;
    
    namespace My.Epic.Website
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
              config.MapHttpAttributeRoutes();
    
              // api/Country/WithStates
              config.Routes.MapHttpRoute(
                name: "ControllerAndActionOnly",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { },
                constraints: new { action = @"^[a-zA-Z]+([\s][a-zA-Z]+)*$" });
    
              config.Routes.MapHttpRoute(
                name: "DefaultActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
              );
        }
        }
    }
