    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var viewResult = filterContext.Result as ViewResultBase;
        if (viewResult != null)
        {
            // the controller action returned either a View or a partialView
            // => we could get its name:
            var name = viewResult.ViewName;
        }
        ...
    }
