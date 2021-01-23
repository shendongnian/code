    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // Get the e-mail address previously submitted by the user if it
            // exists, or use an empty string if it doesn't
            return View(TempData["email"] ?? string.Empty);
        }
        [HttpPost]
        public ActionResult Index(string email)
        {
            // Store the e-mail address submitted by the form in TempData
            TempData["email"] = email;
            return RedirectToAction("Index");
        }
    }
