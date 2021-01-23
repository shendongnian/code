    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            if (context.ActionDescriptor.GetCustomAttributes<DontValidateAttribute>().Any())
            {
                // The controller action is decorated with the [DontValidate]
                // custom attribute => don't do anything.
                return;
            }
    
            if (context.Request.Method.ToString() == "OPTIONS") return;
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                JsonValue errors = new JsonObject();
                foreach (var key in modelState.Keys)
                {
                    // some stuff
                }
    
                context.Response = context.Request.CreateResponse<JsonValue>(HttpStatusCode.BadRequest, errors);
            }
        }
    }
