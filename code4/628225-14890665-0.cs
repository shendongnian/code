    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
       protected override bool AuthorizeCore(HttpContext.User user)
       {
         // Generally authenticated to the site
         if (!httpContext.User.Identity.IsAuthenticated) {
            return false;
         }
        return true;
       }
    }
