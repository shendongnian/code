    public class MyActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.ActionParameters["accountId"] = Guid.NewGuid();
            filterContext.ActionParameters["permission"] = 456;
        }
    }
