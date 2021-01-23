    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GiveFeedback()
        {
            return PartialView(new FeedBack());
        }
        [HttpPost]
        public ActionResult GiveFeedback(FeedBack model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }
            return Json(new { result = "Thanks for submitting your feedback" });
        }
    }
