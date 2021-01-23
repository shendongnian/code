    public class NInjectControllerFactory : DefaultControllerFactory 
    {
        IKernel kernel = new StandardKernel(new HomeModelsDependencies());
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);  
        }
        private class HomeModelsDependencies : NinjectModule
        {
            public override void Load()
            {
                Bind<IHomeModels>().To<HomeModels>();
            }
        }
    }
