    public class CommentsController : Controller
    {
        public ActionResult Index()
        { 
            return View("Articles/Index", model );
        }
    }
    public class ArticlesController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }
    }
