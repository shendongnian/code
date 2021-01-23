    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new ControllerActivator()));
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.Configure(c => c.Scan(scan =>
            {
                scan.AssembliesInBaseDirectory();
                scan.With<UnityConfiguration.FirstInterfaceConvention>().IgnoreInterfacesOnBaseTypes();
            }));
            return container;
        }
    }
    public class ControllerActivator : IControllerActivator
    {
        IController IControllerActivator.Create(RequestContext requestContext, Type controllerType)
        {
            return GlobalConfiguration.Configuration.DependencyResolver.GetService(controllerType) as IController;
        }
    }
