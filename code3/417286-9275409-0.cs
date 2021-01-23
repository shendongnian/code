    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FormsAuthentication.SetAuthCookie("foo", true);
            return View();
        }
        [Authorize]
        public ActionResult Foo()
        {
            return Json(User.Identity.Name + " is still authenticated", JsonRequestBehavior.AllowGet);
        }
    }
