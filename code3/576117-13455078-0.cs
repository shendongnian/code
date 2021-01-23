    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        AreaRegistration.RegisterAllAreas();
        ....
    }
