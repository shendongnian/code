    public class ValidationActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                dynamic errors = new JsonObject();
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        errors[key] = state.Errors.First().ErrorMessage;
                    }
                }
                actionContext.Response = new HttpResponseMessage<JsonValue>(errors, HttpStatusCode.BadRequest);
            }
        }
    }
