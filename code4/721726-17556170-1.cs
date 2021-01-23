    public static void Register(HttpConfiguration config)
    {
        config.Routes.MapHttpRoute(
            name: "NumberedParametersAPI",
            routeTemplate: "WebServices/{controller}/{action}/{Param1}/{Param2}"
        );
        config.Routes.MapHttpRoute(
            name: "CharacterizedParametersAPI",
            routeTemplate: "WebServices/{controller}/{action}/{ParamA}",
            defaults: new { ParamA = RouteParameter.Optional }
        );
    }
