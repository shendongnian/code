    //HomeController.cs
    public class HomeController : Controller
    {
         public ActionResult Index()
         {
             return View();
         }
        public ActionResult DoWork(SomeDTO dto)
        {
            return View("Index");
        }
    }
    public class SomeDTO
    {
        public int SomeId { get; set; }
        public string SomeData { get; set; }
    }
    //Index.cshtml
    @Html.ActionLink("Home", "DoWork", new { SomeId = 1, SomeData = "World" })
    //RouteConfig.cs
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home",
                                action = "Index",
                                id = UrlParameter.Optional }
            );
        }
    }
