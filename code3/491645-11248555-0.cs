    public class MyRazorView : RazorView
    {
        private readonly bool _isPartial;
        public MyRazorView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions, IViewPageActivator viewPageActivator, bool isPartial)
            : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, viewPageActivator)
        {
            _isPartial = isPartial;
        }
        protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
        {
            if (viewContext.Controller is MyController)
            {
                if (_isPartial)
                {
                    // it's a partial
                }
                else
                {
                    // it's the main view
                }
            } 
            base.RenderView(viewContext, writer, instance);
        }
    }
    public class MyRazorViewEngine : RazorViewEngine
    {
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new MyRazorView(
                controllerContext, 
                partialPath, 
                null, 
                false, 
                base.FileExtensions, 
                base.ViewPageActivator, 
                true
            );
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new MyRazorView(
                controllerContext, 
                viewPath, 
                masterPath, 
                true, 
                base.FileExtensions, 
                base.ViewPageActivator, 
                false
            );
        }
    }
