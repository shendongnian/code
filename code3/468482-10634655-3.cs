    public class BaseController : Controller
    {
        public string Sid
        {
            get
            {
                var sid = Session["Sid"];
                return sid == null ? "" : sid.ToString();
            }
            set
            {
                Session["Sid"] = value;
            }
        }
    }
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            Sid = "2343432233aaaa";
            ViewBag.Name = Session["Sid"];
            return View();
        }
    }
    public class TestController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Name = Session["Sid"];
            return View();
        }
    }
