    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class VersionAttribute : FilterAttribute, IActionFilter
    {
        private bool IsValidForRequest(ActionExecutingContext filterContext)
        {
            //my logic here
            return true; //for testing
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsValidForRequest(filterContext))
            {
                filterContext.Result = new HttpNotFoundResult();  //Or whatever other logic you require?
            }
        }
        public void  OnActionExecuted(ActionExecutedContext filterContext)
        {
            //left blank intentionally
        }
    }
