    public class ConfirmedUsersOnly: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var loggedInUser = // pull user from storage
            return httpContext.User.Identity.IsAuthenticated && loggedInUser.confirmed;
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
                // redirect users who are logged in but not confirmed
                filterContext.HttpContext.Response.Redirect("NotConfirmedUrl");
            }
        }
    }
