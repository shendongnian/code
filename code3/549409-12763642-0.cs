    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // execution order: 1
            // your actions here
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // execution order: 2
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // execution order: 3
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // execution order: 4
            base.OnResultExecuted(filterContext);
        }
    }
