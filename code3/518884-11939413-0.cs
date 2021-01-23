      public class GetQueryString: IActionFilter, IMvcFilter
        {
    
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                string siteReference = filterContext.HttpContext.Request["ref"];
            }
    
    
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
    
            }
    
    
            public bool AllowMultiple
            {
                get { return false; }
            }
    
            public int Order
            {
                get { return Filter.DefaultOrder; }
            }
        }
