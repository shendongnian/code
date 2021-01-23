    public class MyAuthorizeAttribute: AuthorizeAttribute
    {
    #if DEBUG
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return true;
        }
    #endif
     }
