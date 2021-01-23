    public class MyCustomActionFilterAttribute : Attribute
    {
    }
    public class MyCustomActionFilter : FilterProvider, IActionFilter
    {
        protected MyService Service { get; private set; }
        // MyService can be injected by the container...
        public MyCustomActionFilter(MyService service)
        {
            this.Service = service;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Check to see if the action has a matching attribute
            var attributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MyCustomActionFilterAttribute), true);
            // Perform some logic here....
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
