    public ActionResult Login(LoginModel)
    {
        if(ModelState.IsValid())
        {
            //Run Further checks & functions
            //Upon successful login, retuns to somewhere (Just site index in this example)
            return RedirectToAction("Index", "Site");
        }
    
        return RenderPartialViewToString("Login",model);
    }
    protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");
    
            ViewData.Model = model;
    
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
