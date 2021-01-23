    protected override void OnException(ExceptionContext filterContext)
    {
        base.OnException(filterContext);
        if (((filterContext.Exception is SecurityException)) ||
            ((filterContext.Exception is AuthenticationException)))
        {
            filterContext.ExceptionHandled = true;
            
            filterContext.Result = View("Error", "You don't have permission");
        }
    }
