    public class MyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Your logic here...
            base.OnActionExecuting(filterContext);
        }
    }
