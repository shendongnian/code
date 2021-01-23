    public void OnException(ExceptionContext filterContext)
    {
        var exception = filterContext.Exception as HttpAntiForgeryException;
        if (exception == null) return;
    
        if (filterContext.HttpContext.Request.IsAjaxRequest())
        {
            filterContext.HttpContext.Response.StatusCode = 403;
            filterContext.ExceptionHandled = true;
        }
        else
        {
            var routeValues = new RouteValueDictionary
            {
                ["controller"] = "Account",
                ["action"] = "Login"
            };
            filterContext.Result = new RedirectToRouteResult(routeValues);
            filterContext.ExceptionHandled = true;
        }
    }
