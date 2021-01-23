    public class HomeController : Controller
    {
       //
       // GET: /Home/
       public ActionResult Index()
       {
          return RedirectToAction("Page", new { id = "Home" });
       }
       public ActionResult Page(string id)
       {
          return View();
       }
    }
