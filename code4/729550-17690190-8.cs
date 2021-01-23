    internal static class ControllerExtensions
    {
      public static string PartialViewToString(this Controller instance, object model)
      {
        string viewName = instance.ControllerContext.RouteData.GetRequiredString("action");
        return ControllerExtensions.PartialViewToString(instance, viewName, model);
      }
      public static string PartialViewToString(this Controller instance, string viewName, object model)
      {
        string result;
        ViewDataDictionary viewData = instance.ViewData;
        viewData.Model = model;
        using (var sw = new StringWriter())
        {
          var viewResult = ViewEngines.Engines.FindPartialView(instance.ControllerContext, viewName);
          var viewContext = new ViewContext(instance.ControllerContext, viewResult.View, viewData, instance.TempData, sw);
          viewResult.View.Render(viewContext, sw);
          viewResult.ViewEngine.ReleaseView(instance.ControllerContext, viewResult.View);
          result = sw.GetStringBuilder().ToString();
	}
        return result;
      }
    }
