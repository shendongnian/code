    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(
            RequestContext requestContext, 
            Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as Controller;
        }
    }
