    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Url.IsLoopback)
            {
                // It was a local request => authorize the guy
                return true;
            }
            return base.AuthorizeCore(httpContext);
        }
    }
