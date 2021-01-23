    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authroized = base.AuthorizeCore(httpContext);
            if (!authroized)
            {
                // the user is not authenticated or the forms authentication
                // cookie has expired
                return false;
            }
    
            // Now check the session:
            var myvar = httpContext.Session["myvar"];
            if (myvar == null)
            {
                // the session has expired
                return false;
            }
    
            return true;
        }
    }
