    public class LogExceptionAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                    base.OnActionExecuting(filterContext);
            }
    
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                    //here you can inspect filterContext for exceptions
                    base.OnActionExecuted(filterContext);
            }
    
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                base.OnResultExecuting(filterContext);
            }
    
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                base.OnResultExecuted(filterContext);
            }
        }
