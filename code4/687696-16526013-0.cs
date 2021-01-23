     public string RenderRazorViewToString(string viewName, object model = null)
     {
       ViewData.Model = model;
       using (sw == new System.IO.StringWriter())
       {
         dynamic viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
	 dynamic viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
	 viewResult.View.Render(viewContext, sw);
	 return sw.GetStringBuilder().ToString();
       }
     }
