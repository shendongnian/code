    public static void Register(HttpConfiguration config)
    {
    	//// Web API routes
    	config.MapHttpAttributeRoutes(); //Don't miss this
    
    	config.Routes.MapHttpRoute(
    		name: "DefaultApi",
    		routeTemplate: "api/{controller}/{id}",
    		defaults: new { id = System.Web.Http.RouteParameter.Optional }
    	);
    }
