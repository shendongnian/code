    namespace MvcApplication1
    {
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Test_default", // Route name
                "Test/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Test", action = "Index", id = "" }, // Parameter defaults
                new string[] { "MvcApplication1.Areas.Test.Controllers" } //namespace
                );
        }
    }
    }
