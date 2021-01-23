        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddModule(string id, string returnTo)
        {
            string content = DemoResolve(id);
            try
            {
                content = RenderView("BLLForumModule");
            }catch(Exception exp)
            {
                throw;
            }
            return Json(new { Target = returnTo, Content = content });
        }
    private string RenderView(string moduleName)
        {
            string result = "";
            IContentModule module = (IContentModule)Activator.CreateInstance(Type.GetType("Foo.Bar." + moduleName  +",Foo.Bar"));
            this.ViewData.Model = module;
            using (var sw = new System.IO.StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines
                .FindPartialView(this.ControllerContext, moduleName);
                
                var viewContext = new ViewContext(this.ControllerContext,
                viewResult.View, this.ViewData, this.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                result = sw.GetStringBuilder().ToString();
                
            }
            return result;
        }
