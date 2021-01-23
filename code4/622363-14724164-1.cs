    public class SignupController : Controller
    {
        public ActionResult Index()
        {
            PFSignup.Models.SpecialtyListsModels objSpecialtyList = new PFSignup.Models.SpecialtyListsModels();
            Dictionary<int, dynamic> specialtyLists = objSpecialtyList.SpecialtyLists();
            return View(specialtyLists);
        }
        [HttpPost]
        public ActionResult Create(SignupModels signup)
        {
            return View(signup);
        }
    }
