    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ValueFromMvc = "this value is coming from MVC";
            return View();
        }
        public ActionResult Back(string valueFromWebForms)
        {
            return Content(string.Format("This value came from WebForms: {0}", valueFromWebForms));
        }
    }
