    public class AController : Controller
    {
          public ActionResult YourView()
          {
             return View();
          }
          [HttpPost]
          public ActionResult YourView(boolean autoreload)
          {
             //autoreload
             return View();
          }
    }
