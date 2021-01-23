    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userIdentity = httpContext.User.Identity;
            if (!userIdentity.IsAuthenticated)
                return false;
             
            var rd = httpContext.Request.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            if(currentAction == "SalesIndex") 
            {
                return IsUserIsInRoleForTheView(userIdentity.Name);    
            }
            
            return true;
        }
    }
    [CustomAuthorize] 
    public ActionResult SalesIndex()
    {
        return View();
    }
