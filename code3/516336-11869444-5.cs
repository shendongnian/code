    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyViewModel());
        }
        [HttpPost]
        public ActionResult Departments(MyViewModel model)
        {
            // TODO: use model.SchoolId to fetch the corresponding departments
            // from your database or something
            model.Departments = new[]
            {
                new SelectListItem { Value = "1", Text = "department 1 for school id " + model.SchoolId },
                new SelectListItem { Value = "2", Text = "department 2 for school id " + model.SchoolId },
                new SelectListItem { Value = "3", Text = "department 3 for school id " + model.SchoolId },
            };
            return View("Index", model);
        }
    }
