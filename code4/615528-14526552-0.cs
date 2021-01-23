        Custom Route
        
    You'd like you can always write your own custom Route class that redirects users to particular area depending on their username/role membership... Although redirection could as well be part of your Login action
        
        [HttpPost]
        public ActionResult Login(LoginCredentials user)
        {
            // authenticate
            ...
            if (User.IsInRole("admin"))
            {
                return this.RedirectToAction("Index", "User", new { area = "Admin" });
            }
            return this.RedirectToAction("Index", "User");
        }
        
        This action assumes there's Admin area in your application.
        Custom route constraint
        
        The other possibility is to have custom route constraints. So you would actually define two routes but one having a particular constraint:
        
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
        
        This way you'd be able to route admins to admin area of your application and provide them with particular functionality they have there. But it doesn't bean that they need an admin area. That's just my route definition. You can define route defaults the way that you want.
