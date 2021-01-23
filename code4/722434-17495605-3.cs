    public class HomeController
    {
        private Model1 model = new Model1();
        public ActionResult Index() 
        {
            return View(model);
        }
        public ActionResult Action1()
        {
            return View(model);
        }
    }
