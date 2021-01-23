    public class ViewNameAttribute : ActionFilterAttribute
    {
        private readonly string _viewName;
        public ViewNameAttribute(string viewName)
        {
            _viewName = viewName;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResultBase;
            if (result != null)
            {
                result.ViewName = _viewName;
            }
        }
    }
