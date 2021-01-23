    public class IsAdminAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IPrincipal principal = actionContext.RequestContext.Principal;
            return principal.IsAdmin();
        }
    }
