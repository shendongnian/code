		public static string RenderPartialViewToString(Controller thisController, string viewName, object model)
		{
			// assign the model of the controller from which this method was called to the instance of the passed controller (a new instance, by the way)
			thisController.ViewData.Model = model;
			// initialize a string builder
			using (StringWriter sw = new StringWriter())
			{
				// find and load the view or partial view, pass it through the controller factory
				ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(thisController.ControllerContext, viewName);
				ViewContext viewContext = new ViewContext(thisController.ControllerContext, viewResult.View, thisController.ViewData, thisController.TempData, sw);
				// render it
				viewResult.View.Render(viewContext, sw);
				//return the razorized view/partial-view as a string
				return sw.ToString();
			}
		}
