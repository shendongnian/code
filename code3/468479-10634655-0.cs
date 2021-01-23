    public class BaseController : Controller
    {
        public string Sid
        {
            get
            {
                var o = Session == null ? Session.SessionID : Session["Sid"];
                return o == null ? "" : o.ToString();
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
            Sid = Session.SessionID;
            ViewBag.Name = Sid;
            return View();
        }
    }
    public class TestController : BaseController
    {
        public ActionResult Index()
        {
            Sid = Session.SessionID;
            ViewBag.Name = Sid;
            return View();
        }
    }
