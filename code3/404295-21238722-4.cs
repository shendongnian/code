    public class CustomControllerFactory : DefaultControllerFactory
        {
            public override IController CreateController(RequestContext requestContext, string controllerName)
            {
                var controller = base.CreateController(requestContext, controllerName);
                HttpContext.Current.Items["controllerInstance"] = controller;
                return controller;
            }
        }
    }
