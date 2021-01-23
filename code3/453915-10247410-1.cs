    protected override void OnException(ExceptionContext filterContext)
    {
        // do some logging using log4net or signal to ELMAH
        filterContext.ExceptionHandled = true;
        View("Error").ExecuteResult(ControllerContext);
    }
