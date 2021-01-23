    using System;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    [assembly: WebActivator.PreApplicationStartMethod(typeof(ABCD.Project.Web.App_Start.NinjectWebCommon), "Start")]
    [assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ABCD.Project.Web.App_Start.NinjectWebCommon), "Stop")]
    namespace ABCD.Project.Web.App_Start
    {
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrap = new Bootstrapper();
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrap.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrap.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            // Set Web API Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //var modules = new INinjectModule[] { new NinjectBindingModule(), };
            //kernel.Load(modules);
            Here's where you would load your modules or define your bindings manually...
        }        
    }
    }
