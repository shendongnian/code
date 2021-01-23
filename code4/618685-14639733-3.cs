    public class HomeController : Controller
        {
            public ActionResult Index()
            {
                //just intentionally add this code so that exception will occur
                int.Parse("test");
                return View();
            }
        }
