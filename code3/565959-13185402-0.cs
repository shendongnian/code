     public class HomeController : Controller
    {
        public ActionResult Me(string id)
        {
            ViewBag.Message = "Welcome to ASP.NET MVC! "+id;
            var contentobj = repository.GetUSerContent(id);
            return View("Index",contentobj);
        }
    } 
