    public class PeopleController: Controller
    {
        private readonly PeopleRepository repo = new PeopleRepository();
    
        public ActionResult Index()
        {
            IList<Person> model = repo.Get();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            IList<Person> model = repo.Get();
            return View("Index", model);
        }
    }
