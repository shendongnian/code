        [HttpPost]
        public JsonResult AddUpdateConfigs(StorageConfigurationModel modelbind)
        {
            if(!allowed) {
              return Json(new { Success = false, Message = "blah blah blah"}, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json( new {Success = true, Html = RenderPartialView("cbpnlNewUpdateConfigs", model)}, JsonRequestBehavior.DenyGet);
            }
        }
        
        public static class PartialViewHelper
            {
                public static string RenderPartialView(this Controller controller, string viewName, object model)
                {
                    if (string.IsNullOrEmpty(viewName))
                        viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
        
                    controller.ViewData.Model = model;
                    using (var sw = new StringWriter())
                    {
                        ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                        var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                        viewResult.View.Render(viewContext, sw);
        
                        return sw.GetStringBuilder().ToString();
                    }
                }
        
                public static string RenderView(this Controller controller, string viewName, object model)
                {
                    if (string.IsNullOrEmpty(viewName))
                        viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
        
                    controller.ViewData.Model = model;
                    using (var sw = new StringWriter())
                    {
                        ViewEngineResult viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, String.Empty);
                        var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                        viewResult.View.Render(viewContext, sw);
        
                        return sw.GetStringBuilder().ToString();
                    }
                }
            }
