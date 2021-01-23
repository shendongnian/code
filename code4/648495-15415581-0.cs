    public class HomeController : Controller
    {
        public ActionResult Index(string search)
        {
            return View(new IndexViewModel(search));
        }
    }
