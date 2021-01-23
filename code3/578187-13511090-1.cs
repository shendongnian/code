    public class HomeController : Controller
        {
            public ActionResult Index(int? page)
            {
                var definedPage = page ?? 0;
                ViewBag.page = "your page is " + definedPage;
                return View();
            }
    
            public ActionResult Article(string article)
            {
                ViewBag.article = article;
                return View();
            }
        }
