    public static HtmlString MyHelper(this HtmlHelper html)
    {
         var controllerContext = html.ViewContext.Controller.ControllerContext;
         ViewEngineResult result = ViewEngines.Engines.FindPartialView(controllerContext, name);
         ...
    }
