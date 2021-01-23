    public class HomeController : Controller
    {
        public ActionResult List()
        {
            ViewBag.Message = "You've accessed User/List";
            return View();
        }
    }
