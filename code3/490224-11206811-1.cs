        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
                return View(new ViewModelOne() { Name = "hello", Something="sdfsdfs", ANumber = 1 });
            }
            public ActionResult About()
            {
                return View(new ViewModelTwo() { Name = "hello 2", SomethingElse = "aaaddd", ANumber2 = 10, Thing="rand" });
            }
        }
