    routes.MapRoute(
        "ActionLess",
        "{controller}/{id}",
        new { controller = "Home", action = "Index" },
        new { id = @"^[0-9]+$" },
        new string[] { "MySite.Web.Controllers" }
    );
    routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        new string[] { "MySite.Web.Controllers" }
    );
