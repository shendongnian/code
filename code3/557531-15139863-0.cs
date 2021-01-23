    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ValidateInputsAttribute : ActionFilterAttribute
    {
        private static readonly IValidatorFactory ValidatorFactory = new AttributedValidatorFactory();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var errors = new Dictionary<string, string>();
            foreach (KeyValuePair<string, object> arg in actionContext.ActionArguments.Where(a => a.Value != null))
            {
                var argType = arg.Value.GetType();
                IValidator validator = ValidatorFactory.GetValidator(argType);
                if (validator != null)
                {
                    var validationResult = validator.Validate(arg.Value);
                    foreach (ValidationFailure error in validationResult.Errors)
                    {
                        errors[error.PropertyName] = error.ErrorMessage;
                    }
                }
            }
            if (errors.Any())
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
