    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // no authenticated user => no need to go any further
                return false;
            }
    
            var routeData = httpContext.Request.RequestContext.RouteData;
            // get the username of the currently authentciated user
            string username = httpContext.User.Identity.Name;
    
            // Get the a parameter
            string a = routeData.Values["a"] as string;
    
            // Get the b parameter
            string b = routeData.Values["b"] as string;
    
            return IsAuthorized(username, a, b);
        }
    
        private bool IsAuthorized(string username, string a, string b)
        {
            // TODO: you know what to do here => hit the database to check
            // whether the user is authorized to work with a and b
            throw new NotImplementedException();
        }
    }
