    public class ModelValidationFilterAttribute : ActionFilterAttribute
    {
        public ModelValidationFilterAttribute() : base()
        {
        }
    
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var scope   = actionContext.Request.GetDependencyScope();
    
            if (scope != null)
            {
                var validator   = scope.GetService(typeof(AccountValidator)) as AccountValidator;
    
                // validate request using validator here...
            }
    
            base.OnActionExecuting(actionContext);
        }
    }
