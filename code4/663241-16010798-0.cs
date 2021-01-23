    public class HomeController: Controller
    {
        private readonly IAppUserRepository repo;
        public HomeController(IAppUserRepository repo)
        {
            this.repo = repo;
        }
    
        public ActionResult Index(int id)
        {
            var model = this.repo.Get(id);
            return View(model);
        }
    }
