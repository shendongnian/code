    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var sitename = filterContext.RouteData.Values["sitename"] as string;
            if (!string.IsNullOrEmpty(sitename))
            {
                var routeValues = new RouteValueDictionary(new
                {
                    controller = "account",
                    action = "login",
                    sitename = sitename,
                });
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
