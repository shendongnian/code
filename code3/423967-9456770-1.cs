    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var sword = new Sword();
            return View((object)sword.Hit("foo"));
        }
    }
