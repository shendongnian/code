    [ResultSwitcherAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View(new TestModel()
                {
                    Web = "http://www.mywebpage.com", Name = "Yngve"
                });
        }
    }
