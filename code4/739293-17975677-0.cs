    protected override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        var viewResult = filterContext.Result as ViewResult;
        var controller = filterContext.Controller;
        using (StringWriter sw = new StringWriter())
        {
            ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
            viewResult.View.Render(viewContext,sw);
            string s = sw.ToString();
        }  
        base.OnResultExecuted(filterContext);
    }
