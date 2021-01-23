    routes.MapRoute(
        "Default", // Route name
        "Home/Collections/{action}/{season}", // URL with parameters
            new { controller = "Collections",
                  action = "Collections",
                  season = UrlParameter.Optional } // Parameter defaults
    );
