    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BindParameterAttribute : ActionFilterAttribute
    {
        public string ViewParameterName { get; set; }
        public string ActionParameterName { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.ContainsKey(ViewParameterName))
            {
                var parameterValue = filterContext.ActionParameters[ViewParameterName];
                filterContext.ActionParameters.Add(ActionParameterName, parameterValue);
            }
            base.OnActionExecuting(filterContext);
        }
    }
