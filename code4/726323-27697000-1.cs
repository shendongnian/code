    public class Startup
        {
            // This code configures Web API. The Startup class is specified as a type
            // parameter in the WebApp.Start method.
            public void Configuration(IAppBuilder appBuilder)
            {
                // Configure Web API for self-host. 
                HttpConfiguration config = new HttpConfiguration();
    
                // Remove the XML formatter (only want JSON) see http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
                config.Formatters.Remove(config.Formatters.XmlFormatter);
                // add jsonp formatter as the one with the highest prio
                config.Formatters.Insert(0, new JsonpMediaTypeFormatter());
    
                // routes
               
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{arg1}/{arg2}",
                    defaults: new { arg1 = RouteParameter.Optional, arg2 = RouteParameter.Optional }
                );
    
                appBuilder.UseWebApi(config);
            }
        }
