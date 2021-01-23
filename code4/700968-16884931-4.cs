    public class ExceptionToJsonNetResultAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                return;
            if (filterContext.Result is JsonNetResult)
                return;
            ProcessException(filterContext);
        }
        private static void ProcessException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new jsonResponseObj(filterContext.Exception);                
            };
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
