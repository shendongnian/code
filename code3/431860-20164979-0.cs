    protected override void HandleUnknownAction(string actionName)
    {
        var Result = View(...);
        using (var Page = new OutputCachedPage(ControllerContext, Result))
        {
            Page.ProcessRequest(HttpContext.ApplicationInstance.Context);
        }
    }
    class OutputCachedPage : Page
    {
        readonly ControllerContext ControllerContext;
        readonly ActionResult Result;
        public OutputCachedPage(ControllerContext controllerContext, ActionResult result)
        {
            if (controllerContext == null) throw new ArgumentNullException("controllerContext");
            if (result == null) throw new ArgumentNullException("result");
            ControllerContext = controllerContext;
            Result = result;
        }
        protected override void FrameworkInitialize()
        {
            base.FrameworkInitialize();
            InitOutputCache(new OutputCacheParameters
                {
                    Enabled = true,
                    Duration = 600,
                    Location = OutputCacheLocation.Any,
                    VaryByParam = "*"
                });
        }
        protected override void Render(HtmlTextWriter writer)
        {
            Result.ExecuteResult(ControllerContext);
        }
    }
