    public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid) 
            {
                
                var errors = new List<string>();
                foreach (var state in modelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                var response = new { errors = errors };
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.BadRequest, response, JsonMediaTypeFormatter.DefaultMediaType);
            }
        }
