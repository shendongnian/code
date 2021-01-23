    public class MyViewEngine : RazorViewEngine
    {
        private class MyRazorView : RazorView
        {
            public MyRazorView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions, IViewPageActivator viewPageActivator)
                : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions)
            {
            }
            protected override void RenderView(ViewContext viewContext, System.IO.TextWriter writer, object instance)
            {
                var stack = viewContext.HttpContext.Items["stack"] as Stack<string>;
                if (stack == null)
                {
                    stack = new Stack<string>();
                    viewContext.HttpContext.Items["stack"] = stack;
                }
                // depending on the required logic you could
                // use a stack of some model and push some additional
                // information about the view (see below)
                stack.Push(this.ViewPath);
                base.RenderView(viewContext, writer, instance);
            }
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new MyRazorView(controllerContext, viewPath, masterPath, true, base.FileExtensions, base.ViewPageActivator);
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new MyRazorView(controllerContext, partialPath, null, false, base.FileExtensions, base.ViewPageActivator);
        }
    }
