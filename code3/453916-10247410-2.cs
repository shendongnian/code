    protected override void OnException(ExceptionContext filterContext)
    {
        // do some logging using log4net or signal to ELMAH
        filterContext.ExceptionHandled = true;
        var exModel = new HandleErrorInfo(filterContext.Exception,  
                      filterContext.RouteData.Values["controller"].ToString(), 
                      filterContext.RouteData.Values["action"].ToString());
        View("Error", exModel).ExecuteResult(ControllerContext);
    }
