    public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            if (filterContext.Exception is HttpAntiForgeryException)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "action", "Index" },
                        { "controller", "Home" }
                    });
                filterContext.ExceptionHandled = true;
            }
    }
