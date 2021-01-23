    public static string RenderPartialToString(ControllerContext context, string partialViewName, ViewDataDictionary viewData, TempDataDictionary tempData)
    {
        var viewEngineResult = ViewEngines.Engines.FindPartialView(context, partialViewName);
    
        if (viewEngineResult.View != null)
        {
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                using (var output = new HtmlTextWriter(stringWriter))
                {
                    ViewContext viewContext = new ViewContext(context, viewEngineResult.View, viewData, tempData, output);
                    viewEngineResult.View.Render(viewContext, output);
                }
            }
    
            return stringBuilder.ToString();
        }
    
        //return string.Empty;
        throw new FileNotFoundException("The view cannot be found", partialViewName);
    }
