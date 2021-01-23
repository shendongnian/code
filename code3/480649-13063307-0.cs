    public class CustomAuthAttribute : AuthorizeAttribute
    {
       private string[] allowedRoles;
    
       public CustomAuthAttribute(params string[] roles)
       {
          allowedRoles = roles;
       }
       protected override bool AuthorizeCore(HttpContextBase httpContext)
       {
         //validate the allowed roles with the user roles.
       }
