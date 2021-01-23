    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            Models.TextViewModel model = new Models.TextViewModel(id);
            return View(model);
        }
    }
