    public class NInjectControllerFactory : DefaultControllerFactory 
    {
        IKernel kernel = new StandardKernel();
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);  
        }
    }
