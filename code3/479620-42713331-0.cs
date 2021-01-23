    public class RedirectFilter : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            if (!IsAuthorized(filterContext))
            {
                filterContext.Result =
                    new RedirectToRouteResult(new RouteValueDictionary(new {controller = "AccessDenied"}));
            }
        }
        private bool IsAuthorized(ActionExecutingContext filterContext)
        {
            var descriptor = filterContext.ActionDescriptor;
            var authorizeAttr = descriptor.GetCustomAttributes(typeof(AuthorizeAttribute), false).FirstOrDefault() as AuthorizeAttribute;
            if (authorizeAttr != null)
            {
                if(!authorizeAttr.Users.Contains(filterContext.HttpContext.User.ToString()))
                return false;
            }
            return true;
        }
    }
