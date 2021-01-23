      public static string RenderPartialToString(string view, object model, ControllerContext Context)
            {
                if (string.IsNullOrEmpty(view))
                {
                    view = Context.RouteData.GetRequiredString("action");
                }
    
                ViewDataDictionary ViewData = new ViewDataDictionary();
    
                TempDataDictionary TempData = new TempDataDictionary();
    
                ViewData.Model = model;
    
                using (StringWriter sw = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(Context, view);
    
                    ViewContext viewContext = new ViewContext(Context, viewResult.View, ViewData, TempData, sw);
    
                    viewResult.View.Render(viewContext, sw);
    
                    return sw.GetStringBuilder().ToString();
                }
            }
            //"Error" should be name of the partial view, I was just testing with partial error view
            //You can put whichever controller you want instead of HomeController it will be the same
            //You can pass model instead of null
            private string returnView()
            {
                return RenderPartialToString("Error", null, new ControllerContext(this.Request.RequestContext, new HomeController()));
            }
