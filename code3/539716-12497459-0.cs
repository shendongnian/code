    routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Category", action = "Details", id = UrlParameter.Optional     } // Parameter defaults
            );
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Details(string id)
        {
            return View();
        }
    }
