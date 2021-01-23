    public static string RenderPartialViewToString(Controller controller, string viewName, object model)
    {
        var oldModel = controller.ViewData.Model;
        controller.ViewData.Model = model;
        try
        {
            using (var sw = new StringWriter())
            {
                controller.RouteData.Values["controller"] = "Email";
                var viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    
                viewResult.View.Render(viewContext, sw);
                controller.ViewData.Model = oldModel;
                return sw.GetStringBuilder().ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
