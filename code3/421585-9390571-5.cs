    routes.MapRoute(
               "Page-wall", // Route name
               "page/{id}/{name}/wall", // URL with parameters
               new { controller = "wall", action = "details", id = "", name = "",
                                                       /*See this>>>> */ obj="page"},
               new { id = @"\d+" },
               new string[] { "PagesNameSpace.Controllers" } // Parameter defaults
               );
    
    routes.MapRoute(
               "profile-wall", // Route name
               "profile/{id}/{name}/wall", // URL with parameters
               new { controller = "wall", action = "details", id = "", name = "",
                                                 /*See this>>>> */ obj="profile" },
               new { id = @"\d+" },
               new string[] { "ProfileNameSpace.Controllers" }
               );
