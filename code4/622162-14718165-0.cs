    var routeData = new RouteData();
    routeData.Values["controller"] = "Error";
    routeData.Values["action"] = "General";
    routeData.Values["exception"] = exception;
    IController errorsController = new ErrorController();
    var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
    try
    {
        errorsController.Execute(rc);
    }
    catch (Exception ex)
    {
        // Appropriate error handling.
    }
