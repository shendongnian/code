    routes.MapRoute(
        "Default", // Route name
        "Home/Collections/{action}/{season}", // URL with parameters
            new { controller = "Collections",
                  action = "Collection",
                  season = UrlParameter.Optional } // Parameter defaults
    );
