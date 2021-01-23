    public class AgreedToDisclaimerAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           if (httpContext == null)
            throw new ArgumentNullException("httpContext");
           // logic to check if they have agreed to disclaimer (cookie, session, database)
           return true;
        }
       protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
       {
              // Returns HTTP 401 by default - see HttpUnauthorizedResult.cs.
               filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary 
                {
                 { "action", "ActionName" },
                 { "controller", "ControllerName" },
                 { "parameterName", "parameterValue" }
                });
       }
    }
