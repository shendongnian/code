    public class XyzApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Ninject dependency injection configuration
            var kernel = new StandardKernel();
            //Your dependency bindings
            kernel.Bind<IXyzRepository>().To<EFXyzRepository>();            
            GlobalConfiguration.Configuration.DependencyResolver = new NInjectDependencyResolver(kernel);
        }
    }
