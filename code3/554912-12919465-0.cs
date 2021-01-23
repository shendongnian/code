    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var ip = httpContext.Request.UserHostAddress;
            if (IsIntranetAddress(ip))
            {
                // The IP address of the client belongs on the intranet => 
                // allow anonymous access
                return true;
            }
            return base.AuthorizeCore(httpContext);
        }
        private bool IsIntranetAddress(string ip)
        {
            throw new NotImplementedException();
        }
    }
