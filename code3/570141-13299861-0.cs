    public interface IActionFilter
    {
        // Summary:
        //     Called after the action method executes.
        //
        void OnActionExecuted(ActionExecutedContext filterContext);
        //
        // Summary:
        //     Called before an action method executes.
        //
        void OnActionExecuting(ActionExecutingContext filterContext);
    }
