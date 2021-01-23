    public class CheckSessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["MyObject"] == null)
            {
                // redirect must happen OnActionExecuting (not OnActionExecuted)
                filterContext.Result = new RedirectToRouteResult(
                  new System.Web.Routing.RouteValueDictionary {
                  {"controller", "Tools"}, {"action", "CreateSession"}
    
            }
            base.OnActionExecuting(filterContext);
        }   
    }
