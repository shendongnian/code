    public class AttributeForTestAttribute : ActionFilterAttribute
    {
        public int RoleCanAccess { get; set; }
    
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
              base.OnActionExecuting(filterContext);
    
              //your validation here..
              //for example:
    
              if(_currentUser.Role < RoleHasAccess )
              {
                //user has not access to this action, redirect him to home page. 
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" }, { "returnUri", filterContext.HttpContext.Request.RawUrl } });
              }
              else
              {
                // user has access to this action
              }
        }
    }
