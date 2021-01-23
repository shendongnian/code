    [Attribute]
    public class TokenLoginAttribute : AuthorizeAttribute
    {
        public overrides void OnAuthorization(AuthorizationContext filterContext)
        {
            // Perform your authorization / login based on token here
        }
    }
    
