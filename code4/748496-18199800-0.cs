    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = false;
            var username = httpContext.User.Identity.Name;
            // Some code to find the user in the database...
            var user = _unitOfWork.UserRepository.Find(username);
            if(user != null)
            {
               // Check if there are Details for the user in the database
               if(user.HasDetails)
               {
                 isAuthorized = true;
               }
            }
    
    
            return isAuthorized;
        }
    
        public override void OnAuthorization(AuthorizationContext filterContext)
        {            
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
    
            if (!AuthorizeCore(filterContext.HttpContext))
            {
               // If not authorized, redirect to the Details action 
               // of the Account controller... 
              filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary {
                   {"controller", "Account"}, {"action", "Details"}
                }
              );               
            }
        }
    }
