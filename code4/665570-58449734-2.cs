    public class WebApiApplication : System.Web.HttpApplication
    {
      protected void Application_Start()
      {
        AreaRegistration.RegisterAllAreas();
        UnityConfig.RegisterComponents();                           // <----- Add this line
        GlobalConfiguration.Configure(WebApiConfig.Register);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
      }           
    }  
