    public class CheckSessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["MyObject"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary {
                {"controller", "Tools"}, {"action", "CreateSession"}
    
            }
            base.OnActionExecuted(filterContext);
        }   
    }
