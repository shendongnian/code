        public string RenderViewToString(string viewName, object model, string layoutName)
        {
            ControllerCurrent.ViewData.Model = model;
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerCurrent.ControllerContext, viewName, layoutName);
                    ViewContext viewContext = new ViewContext(ControllerCurrent.ControllerContext, viewResult.View, ControllerCurrent.ViewData, ControllerCurrent.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
