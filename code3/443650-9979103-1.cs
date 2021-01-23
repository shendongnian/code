    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            // Get the value of the input named `email`
            var email = Request.Form["email"];
            return RedirectToAction("Index");
        }
    }
