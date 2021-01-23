    protected override void OnException(ExceptionContext contextFilter)
    {
        // Here you test if the exception is what you are expecting
        if (contextFilter.Exception is YourExpectedException)
        {
            // Switch to an error view
            ...
        }
        //Also, if you want to handle the exception based on the action called, you can do this:
        string actionName = contextFilter.RouteData.Values["action"];
        //If you also want the controller name (not needed in this case, but adding for knowledge)
        string controllerName = contextFilter.RouteData.Values["controller"];
        string[] actionsToHandle = {"ActionA", "ActionB", "ActionC" };
        
        if (actionsTohandle.Contains(actionName)) 
        {
             //Do your handling.
        }
        //Otherwise, let the base OnException method handle it.
        base.OnException(contextFilter);
    }
