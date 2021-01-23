    public class HomeController : Controller
    {
        private IRepository<SomeEntityType> _repo;
        public HomeController(IRepository<SomeEntityType> repo)
        {
            _repo= repo;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application. " +
                              _repo.HelloWorld();
            return View();
        }
    }
