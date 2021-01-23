    routes.MapRoute(
                    "Regis", // Route nameRegister
                    "Artical/{id}", // URL with parameters
                    new { controller = "Artical", action = "Show", id = UrlParameter.Optional } // Parameter defaults
                );
