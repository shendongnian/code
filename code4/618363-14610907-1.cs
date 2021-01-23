    public class CheckSessionFilterAttribute : ActionFilterAttribute
    {
        public override void onactionexecuting(ActionExecutedContext filterContext)
        {
            if (Session["MyObject"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
        new System.Web.Routing.RouteValueDictionary {
            {"controller", "Tools"}, {"action", "CreateSession"}
    
            }
            base.OnActionExecuted(filterContext);
        }   
    }
