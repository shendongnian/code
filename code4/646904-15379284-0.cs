    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var routeValues = new RouteValueDictionary(new
            {
                controller = "login",
                action = "login",
                area = "admin"
            });
            filterContext.Result = new RedirectToRouteResult(routeValues);
        }
    }
