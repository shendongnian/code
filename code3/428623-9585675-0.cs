     routes.MapRoute(
                "Collections", // Route name
                "Collections/{name}/{id}", // URL with parameters
                new { controller = "Collections", action = "Collection" ,id = UrlParameter.Optional } // Parameter defaults
            );
