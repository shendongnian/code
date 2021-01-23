    public class MyController : Controller
    {
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] // will disable caching for Index only
        public ActionResult Index()
        {
           return View();
        }
    } 
