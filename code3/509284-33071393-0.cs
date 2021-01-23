    public class ModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest};
            }
        }
    }
