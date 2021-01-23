    public class WebApiApplication : System.Web.HttpApplication
    {
        void ConfigureApi(HttpConfiguration config)
        {
            config.DependencyResolver = new MyDependencyResolver();
        }
    
        protected void Application_Start()
        {
            ConfigureApi(GlobalConfiguration.Configuration);
    
            // ...
        }
    }
