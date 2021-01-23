    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var model = filterContext.Controller.ViewData.Model;
        ...
    }
