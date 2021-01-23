       public class HomeController : Controller
        {
            public ActionResult Index()
            {
                var first = new FirstModel();
                var second = new SecondModel();
         
                return View(Tuple.Create(first,second));
            }
        }
