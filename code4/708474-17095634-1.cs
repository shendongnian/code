    public class PropagateTenantToViewDataFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["tenant"] =
                filterContext.RouteData.Values["tenant"];
        }
    }
