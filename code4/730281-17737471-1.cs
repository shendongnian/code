    public class RedirectController : Controller
    {
        public ActionResult Home()
        {
            return RedirectPermanent("~/");
        }
        public ActionResult News()
        {
            return RedirectPermanent("~/News/");
        }
        public ActionResult ContactUs()
        {
            return RedirectPermanent("~/ContactUs/");
        }
        // A method for each of my Controllers
    }
