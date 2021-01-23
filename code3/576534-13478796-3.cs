    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            bool result = false;
            IPrincipal user = httpContext.User;
            
            if (user.Identity.IsAuthenticated)
            {
                result = user.IsAdmin();
            }
            return result;
        }
    }
