    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
      protected override bool AuthorizeCore(HttpContextBase httpContext)
      {
        if (httpContext == null)
        {
          throw new ArgumentNullException("httpContext");
        }
    
        // Check if user is authenticated
        IPrincipal user = httpContext.User;
        if (!user.Identity.IsAuthenticated)
        {
          return false;
        }
    
        if (!httpContext.Request.IsAjaxRequest()) 
        {
             // do your thing in the DB
        }
