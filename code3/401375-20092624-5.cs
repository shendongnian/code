    public static class ControllerExtensions
    {
        public static string RenderView(this Controller controller, object model)
        {
            string viewName = controller.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = controller.ControllerContext.RouteData.Values["controller"].ToString();
            return RenderView(controllerName, viewName, model);
        }
        public static string RenderView(this Controller controller, string viewName, object model)
        {
            string controllerName = controller.ControllerContext.RouteData.Values["controller"].ToString();
            return RenderView(controllerName, viewName, model);
        }
        public static string RenderView(string controllerName, string viewName, object viewData)
        {
            //Create memory writer
            var writer = new StringWriter();
            var routeData = new RouteData();
            routeData.Values.Add("controller", controllerName);
            //Create fake http context to render the view
            var fakeRequest = new HttpRequest(null, "http://tempuri.org", null);
            var fakeResponse = new HttpResponse(null);
            var fakeContext = new HttpContext(fakeRequest, fakeResponse);
            var fakeControllerContext = new ControllerContext(new HttpContextWrapper(fakeContext), routeData, new FakeController());
            var razorViewEngine = new RazorViewEngine();
            var razorViewResult = razorViewEngine.FindView(fakeControllerContext,viewName,"",false);
            var viewContext = new ViewContext(fakeControllerContext, razorViewResult.View, new ViewDataDictionary(viewData), new TempDataDictionary(), writer);
            razorViewResult.View.Render(viewContext, writer);
            return writer.ToString();
        }
    }
