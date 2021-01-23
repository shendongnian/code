    public class RequiresModelAttribute : ActionFilterAttribute
    {
        private readonly string _modelName;
        public RequiresModelAttribute(string modelName)
        {
            _modelName = modelName;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var property = filterContext.Controller.GetType().GetProperty(_modelName);
            var model = property.GetValue(filterContext.Controller);
            if (model == null)
            {
                filterContext.Result = new HttpStatusCodeResult(404);
            }
        }
    }
