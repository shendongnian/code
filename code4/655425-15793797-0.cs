        public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Membership.IslogedIn)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                    {
                                       { "area",""},
                                       { "action", "login" },
                                       { "controller", "user" },
                                       { "redirecturl",filterContext.RequestContext.HttpContext.Request.RawUrl}
                                   });
            }
        }
    }
