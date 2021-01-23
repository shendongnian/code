    public class UserAuthenticatedAction : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsContextFromLoginController(filterContext))
            {
                return;
            }
            
            //...Do whatever you need to check.
            if (userNotAllowed){
                SetRedirectToLoginErrorPageForContext(filterContext);
            }
    
            return;
        }
    
        private static void SetRedirectToLoginErrorPageForContext(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "LoginError" },
                        { "targeturl" , filterContext.RequestContext.HttpContext.Request.Url.ToString()} }
                    });
        }
    
        private static bool IsContextFromLoginController(AuthorizationContext filterContext)
        {
            var controllerName = GetCurrentControllerName(filterContext);
    
            return controllerName.Equals("Login");
        }
    
        private static string GetCurrentControllerName(AuthorizationContext filterContext)
        {
            return filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        }
    }
