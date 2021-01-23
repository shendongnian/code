    public class HomeController : Controller
    {
       public ActionResult Index()
       {
          ViewBag.Message = "Your message";
          return View();
       }
    }
