    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResultBase;
            if (result != null)
            {
                var user = filterContext.HttpContext.User;
                if (user.IsInRole("Admin"))
                {
                    result.ViewName = string.Format("{0}.Admin", filterContext.ActionDescriptor.ActionName);
                }
                else if (user.IsInRole("Power"))
                {
                    result.ViewName = string.Format("{0}.Power", filterContext.ActionDescriptor.ActionName);
                }
            }
        }
    }
