    public static string RenderViewToString(string viewName, object model, ControllerContext context)
    {
        context.Controller.ViewData.Model = model;
        using (var sw = new StringWriter())
        {
            var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
            var viewContext = new ViewContext(context, viewResult.View, context.Controller.ViewData, context.Controller.TempData, sw);
            viewResult.View.Render(viewContext, sw);
            return sw.GetStringBuilder().ToString();
        }
    }
