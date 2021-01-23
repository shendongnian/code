    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                ...
            }
            else if (filterContext.Result is JsonResult)
            {
                ...
            }
            ...
        }
    }
