    public class CustomAuthorize: AuthorizeAttribute
    {
        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
               filterContext.Result = new RedirectToRouteResult(new 
                   RouteValueDictionary(new { controller = "AccessDenied" }));
            }
        }
    }
