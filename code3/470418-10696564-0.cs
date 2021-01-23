        public class HomeController : Controller
        {
             public ActionResult Index()
             {
                return View(new MyViewModel
                {
                    DateOfBirth = DateTime.Now
                });
            }
        }
