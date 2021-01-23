    public class HomeController : Controller
    {
        [OutputCache(Duration = 60, Location = OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return Content(DateTime.Now.ToLongTimeString());
        }
        public ActionResult InvalidateCacheForIndexAction()
        {
            string path = Url.Action("index");
            Response.RemoveOutputCacheItem(path);
            return Content("cache invalidated, you could now go back to the index action");
        }
    }
