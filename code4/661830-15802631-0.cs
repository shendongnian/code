    public class CustomizedAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //check for role in session variable "ADMIN_ROLE"
    
    	//if not valid user then set
    	filterContext.Result = new RedirectResult(URL)
        }
    }
