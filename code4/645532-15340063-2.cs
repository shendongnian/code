    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
             
            var rd = httpContext.Request.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            if(currentAction == "SalesIndex") {
                return IsUserInRoleBasedOnAViewOrWhatever(httpContext.User.Identity.Name);    
            }
            
            return true;
        }
    }
    [CustomAuthorize] 
    public ActionResult SalesIndex(){
        return View();
    }
