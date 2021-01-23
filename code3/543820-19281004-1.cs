    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
        config.Routes.MapHttpRoute(
           name: "LocationApiPOST",
           routeTemplate: "api/{orgname}/{fleetname}/vehicle/location",
           defaults: new { controller = "location" }
           constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
       );
        config.Routes.MapHttpRoute(
           name: "LocationApiGET",
           routeTemplate: "api/{orgname}/{fleetname}/{vehiclename}/location/{start}",
           defaults: new { controller = "location", start = RouteParameter.Optional }
           constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
       );
       ...
    }
