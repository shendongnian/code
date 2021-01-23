    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        foreach(var parameter in filterContext.ActionParameters)
        {
            if (parameter.Key == "pageModuleId")
            {
                 // do something with pageModuleId
            }
        }
        base.OnActionExecuting(filterContext);
    }
