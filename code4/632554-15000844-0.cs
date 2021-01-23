    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string controllerName = filterContext.Controller.GetType().Name;
        string actionName = filterContext.ActionDescriptor.ActionName;
        if (SessionManager.Instance().GetUser() == null ) 
        {
            if(!controllerName.Equals(typeof(HomeController).Name,StringComparison.InvariantCultureIgnoreCase)
            || !actionName .Equals("LogOn",StringComparison.InvariantCultureIgnoreCase)))
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "Controller", "Home" },
                    { "Action", "LogOn" }
            });
        }
        base.OnActionExecuting(filterContext);
    }
