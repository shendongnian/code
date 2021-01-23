        routes.MapRoute(
            "Admin", // Route name
            "{controller}/{action}/{id}", 
            new { area = "Admin", controller = "User", action = "Index", id = UrlParameter.Optional },
            new { isAdmin = new AdminRouteConstraint() }
        );
        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", 
            new { controller = "User", action = "Index", id = UrlParameter.Optional } 
        );
        
