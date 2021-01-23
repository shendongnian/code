    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return new CustomActionResult();
        }
    }
