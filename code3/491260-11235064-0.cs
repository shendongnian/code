    public class MvcApplication : System.Web.HttpApplication
      {
    ...
        public static void RegisterRoutes(RouteCollection routes)
        {
          routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
          routes.MapRoute(
              "Default", // Route name
              "{controller}/{action}/{id}", // URL with parameters
              new { controller = "Test", action = "Index", id = UrlParameter.Optional } // Parameter defaults
          );
    
        }
