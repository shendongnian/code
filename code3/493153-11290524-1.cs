        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Index(string shortName, EditSubmissionModel model)
            {
                return Content(model.submission.Title);
            }
        }
