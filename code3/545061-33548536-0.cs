    [assembly: OwinStartup(typeof(YourCompany.API.Startup))]
    namespace YourCompany.API
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();
                var dependencyResolver = new WindsorHttpDependencyResolver(container);
                config.DependencyResolver = dependencyResolver;
                // ....... 
                // ....... 
            }
        }
    }
