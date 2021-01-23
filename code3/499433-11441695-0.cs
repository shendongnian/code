    public class AuthorizeSuperAdminAttribute : AuthorizeAttribute
    {
         protected virtual bool AuthorizeCore(HttpContextBase httpContext) 
         {    
             IPrincipal user = httpContext.User; 
             if (user.Identity.IsAuthenticated && user.IsInRole("SuperAdmin"))
                    return true;
     
             return base.AuthorizeCore(httpContext);    
         }
    }
