    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session["Sid"] = Session.SessionID;
            base.OnActionExecuting(filterContext);
        }        
    }
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
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
