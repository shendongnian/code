    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "Home_Default",
            "",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "MVCAreas01.Areas.Admin.Controllers" });
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "MVCAreas01.Controllers" }
        );
    }
