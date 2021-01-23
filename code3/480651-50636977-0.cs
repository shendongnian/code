       //Custom Authorize class that derives from the existing AuthorizeAttribute
        public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
           
            private string[] _allowedRoles;
    
            public CustomAuthorizeAttribute(params string[] roles)
            {
                //allowed roles
                _allowedRoles = roles;
            }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var roleManager = httpContext.GetOwinContext().Get<ApplicationUserManager>();
                //Grab all of the Roles for the current user
                var roles = roleManager.GetRoles(httpContext.User.Identity.GetUserId());
                //Determine if they are currently in any of the required roles (and allow / disallow accordingly) 
                return _allowedRoles.Any(x => roles.Contains(x));
            }
        }
