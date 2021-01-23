    public class MyControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName);
            HttpContext.Current.Request["controllerInstance"] = controller;
            return controller;
        }
    }
