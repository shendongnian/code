    public static void Register(HttpConfiguration config)
        { 
                config.Routes.MapHttpRoute(
                                name: "DefaultApi",
                                routeTemplate: "api/{controller}/{id}",
                                defaults: new { id = RouteParameter.Optional }
                            );
                var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();  /*this line makes no more null when use [FromBody]*/
    }
