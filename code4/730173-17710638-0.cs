    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
             IController controller = null;
             Type controllerType;
             if (ControllerTypes.TryGetValue(controllerName.ToLower(), out controllerType))
             {
                  controller = (IController) Activator.CreateInstance(controllerType);
             }
             return controller;
        }
        ...
    }
