    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.With.AutoMapper().Start();
            Bootstrapper.With.Ninject()
                .WithContainer(NinjectWebCommon.Kernel) // Use the kernel inside NinjectWebCommon instead of creating a new one
                .Start();
        }
    }
