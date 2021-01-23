    config.Routes.MapHttpRoute(
                name: "GetByCoordinatesRoute",
                routeTemplate: "/GetByCoordinatesRoute/{*coords}",
                defaults: new { controller = "MyController", action = "GetByCoordinatesRoute" }
    public ActionResult GetByCoordinatesRoute(string coords)
    {
        int[][] coordArray = ... // custom parsing code
    }
