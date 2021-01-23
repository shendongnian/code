    protected override ActionResult InvokeActionMethod(...)
    {
        // Get hostname
        var hostname = controllerContext.HttpContext.Request.Url.Host;
        if (hostname == "some value you want")
        {
            controllerContext.RouteData.DataTokens["area"] = "your area here";
        }
        return base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
    }
