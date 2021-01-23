    public class PersonController: Controller
    {
        public ActionResult Index()
        {
            IEnumerable<PersonViewModel> model = ... talk to your DAL and populate the view model
            return View(model);
        }
    }
