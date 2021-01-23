    public class ConfirmedUsersOnly: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // are they logged in?
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
            return // user is confirmed
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                // handle normal unauthorized redirect (e.g. login page)
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                // handle users who haven't confirmed
                filterContext.HttpContext.Response.Redirect("NotConfirmedUrl");
            }
        }
    }
