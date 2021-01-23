    public class SwitchableAuthorizationAttribute : AuthorizeAttribute
    {
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        bool disableAuthentication = false;
        #if DEBUG
        disableAuthentication = true;
        #endif
        if (disableAuthentication)
            return true;
        return base.AuthorizeCore(httpContext);
    }
    }
