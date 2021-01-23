    public class MyActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(
                HttpStatusCode.OK, 
                new { foo = "bar" }, 
                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
            );
        }
    }
