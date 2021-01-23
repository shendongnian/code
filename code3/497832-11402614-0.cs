    routes.MapRoute("Debate Details", 
                    "debate/{id}", 
                     new { controller = "Debate", 
                           action = "DebateDetails",
                           // this id value is missing 
                           // so it's not being passed to the controller
                           id = UrlParameter.Optional } );
