    public class HomeController : Controller
        {
            public ActionResult SetName(int id)
            {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
    
                return View();
            }
        }
