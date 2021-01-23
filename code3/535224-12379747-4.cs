    public class HonorHttpExceptionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpException = filterContext.HttpContext.AllErrors.FirstOrDefault(x => x is HttpException) as HttpException;
            if (httpException != null)
            {
                filterContext.Result = new HttpStatusCodeResult(httpException.GetHttpCode());
            }
        }
    }
