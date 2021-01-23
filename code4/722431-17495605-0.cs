    public class HomeController
    {
        public ActionResult Index() 
        {
            return View(new Model1());
        }
        public ActionResult Action1()
        {
            return View(new Model1());
        }
    }
