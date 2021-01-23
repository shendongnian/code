    public class HomeController : Controller
    {
        public IMsgService Service { get; set; }
        public ActionResult Index()
        {
            return Content(Service.GetMessage());
        }
	}
