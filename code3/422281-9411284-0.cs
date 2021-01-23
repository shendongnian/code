    public class LogOnAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!SessionWrapper.IsAuthenticated)
            {
                filterContext.Result = new ViewResult {ViewName = "AccessDenied"};
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
