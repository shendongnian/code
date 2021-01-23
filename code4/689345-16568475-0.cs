     public static string GetTemplateContentInstance(ControllerContext controllerContext, string viewName, object model)
        {
            if (string.IsNullOrWhiteSpace(viewName))
                //Return name of view for current action
                viewName = controllerContext.RouteData.GetRequiredString("action");
            controllerContext.Controller.ViewData.Model = model;
            using (StringWriter stringWriter = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                ViewContext viewContext = new ViewContext(controllerContext, viewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
