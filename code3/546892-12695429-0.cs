    public class NullFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;
            object responseValue;
            bool hasContent = response.TryGetContentValue(out responseValue);
            if (!hasContent)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
