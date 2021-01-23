    public class WebAPIActionFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            PersonController.Messages.Add("OnActionExecuted");
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            PersonController.Messages.Add("OnActionExecuting");
        }
    }
    public class WebAPIExceptionFilter : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            PersonController.Messages.Add("OnException");
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent("Something went wrong") };
        }
    }
