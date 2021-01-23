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
