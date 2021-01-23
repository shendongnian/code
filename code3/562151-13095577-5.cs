    public class SessionValidationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
           if (filterContext.Result == null)
           {
              var id = filterContext.RouteData.Values["id"] as string;
              if (id == null || id == "")
              {
                // check cookie
                if (filterContext.Controller.ControllerContext
                   .HttpContext.Request.Cookies.AllKeys
                   .Contains("cookiename"))
                {
                    // if a session cookie was found,
                    // send to the registration recovery page
                    string sessionGuidCookieValue = "";
                    sessionGuidCookieValue = filterContext.Controller
                        .ControllerContext.HttpContext.Request
                        .Cookies["cookiename"].Value;
                    // check if GUID/SessionID exists in persistent cache
                    // send to Session Recovery
                    string redirectURL = @"~/SessionRecovery/Index/"
                            + sessionGuidCookieValue;
                    // this code isn't working
                    filterContext.Result = new RedirectResult(redirectURL);
                }
              }
           }
        }
        public abstract bool CanAccessResource(User user);
    }
