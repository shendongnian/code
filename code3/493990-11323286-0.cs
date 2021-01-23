    else
    {
        string controllerName = filterContext.RouteData.GetRequiredString("controller");
        string actionName = filterContext.RouteData.GetRequiredString("action");
        var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
        var result = new ViewResult
        {
            ViewName = "Error",
            ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
        };
        filterContext.Result = result;
    }
