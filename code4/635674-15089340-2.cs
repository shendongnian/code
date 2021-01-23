    public class ValidVerbAndRouteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            object id;
            if (actionExecutedContext.ActionContext.ActionArguments.TryGetValue("id", out id) &&
                actionExecutedContext.Request.Method == HttpMethod.Post)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    } 
