    public override void OnException(HttpActionExecutedContext actionExecutedContext)
    {
        var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
        var controllerName =
            actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        Logger.LogException(controllerName + ":" + actionName, actionExecutedContext.Exception);
        actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                                             {
                                                 ReasonPhrase = YourPhrase
                                             };
    }
