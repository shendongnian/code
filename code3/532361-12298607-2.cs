    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BindParameterAttribute : ActionFilterAttribute
    {
        public string ViewParameterName { get; set; }
        public string ActionParameterName { get; set; }
    
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var viewParameter = actionContext.Request.RequestUri.ParseQueryString()[ViewParameterName];
            if (!string.IsNullOrWhiteSpace(viewParameter))
                actionContext.ActionArguments[ActionParameterName] = viewParameter;
    
            base.OnActionExecuting(actionContext);
        }
    }
