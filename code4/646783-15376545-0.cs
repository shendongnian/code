    namespace ListBindingTest.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /Home/
            public ActionResult Index()
            {
                List<String> tmp = new List<String>();
                tmp.Add("one");
                tmp.Add("two");
                tmp.Add("Three");
                return View(tmp);
            }
            [HttpPost]
            public ActionResult Send(IList<String> input)
            {
                return View(input);
            }    
        }
    }
