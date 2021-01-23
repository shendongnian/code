    public class HomeController : Controller
    {
        public ActionResult Index(string friendlyName)
        {
            int pupilId = Data.People.Single(x => x.Name == friendlyName).PersonId;
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel {PupilId = pupilId};
            return View(homeIndexViewModel);
        }
    }
