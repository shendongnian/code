    protected override void OnException(ExceptionContext filterContext)
    {
        if (filterContext.ExceptionHandled)
        {
            return;
        }
        filterContext.Result = new ViewResult
        {
            ViewName = ...
        };
        filterContext.ExceptionHandled = true;
    }
