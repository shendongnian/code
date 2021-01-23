    public class CommentsController : Controller
    {
        public ActionResult Index()
        { 
            return View("../Articles/Index", model );
        }
    }
