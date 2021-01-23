    public class FooFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var tenant = filterContext.RouteData.Values["tenant"]
            //do whatever you need to do before executing the action, based on the tenant 
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var tenant = filterContext.RouteData.Values["tenant"]
            //do whatever you need to do after executing the action, based on the tenant
        }
    }
