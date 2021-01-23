    private string GetPhysicalPath(string viewName, string controller)
    {
		ControllerContext context = CloneControllerContext();
		if (!controller.NullOrEmpty())
		{
	    	context.RouteData.Values["controller"] = controller;
		}
		if (viewName.NullOrEmpty())
		{
			viewName = context.RouteData.GetActionString();
		}
		IView view = ViewEngines.Engines.FindView(viewName, context).View;
        string physicalPath = view.GetViewPath();
        return physicalPath;
    }
