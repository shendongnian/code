        public class MvcApplication : NinjectHttpApplication
        {
           protected override IKernel CreateKernel()
           {
               IKernel kernel = new StandardKernel();
               
               // kernel.Load(Assembly.GetExecutingAssembly());
               
               // kernel.Bind<ISomeClass>().To<SomeClass>();
               
               return kernel;
           }
           protected override void OnApplicationStarted()
           {
               AreaRegistration.RegisterAllAreas();
               
               WebApiConfig.Register(GlobalConfiguration.Configuration);
               FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
               RouteConfig.RegisterRoutes(RouteTable.Routes);
               BundleConfig.RegisterBundles(BundleTable.Bundles);
               ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(Kernel));
           }
        }
