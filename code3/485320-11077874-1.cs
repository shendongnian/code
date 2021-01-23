    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SurveyEmailListModels[] model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ... store the model into the database 
            return Content("Thanks for uploading");
        }
    }
