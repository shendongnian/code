    public class ConfirmedUsersOnly: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // are they logged in?
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
            return // user is confirmed
        }
    }
    [ConfirmedUsersOnly]
    public ActionResult ConfirmedAccountAction()
    {
        ...
    }
