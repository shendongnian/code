        [AttributeUsage(AttributeTargets.All)]
        public sealed class CustomAuthorizeAttribute : AuthorizeAttribute
        {
    
       protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            
            //Its a piece of code from my app you can modify it to suit your needs or use the base one
            if (!new CustomIdentity(httpContext.User.Identity.Name).IsAuthenticated)
            {
                return false;
            }
    
            return true;
        }
    
        protected override void HandleUnauthorizedRequest(AuthorizationContext    filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
    
         }
    
    }
