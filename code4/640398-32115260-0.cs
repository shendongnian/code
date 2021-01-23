    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["hello"] = "test"; // still alive
            return RedirectToAction("About");
        }
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            var sonename = TempData["hello"]; // still alive (second time)
            return RedirectToAction("Contact");
        }
      
        public ActionResult Contact()
        {
            var scondtime = TempData["hello"]; // still alive(third time)
            return View();
        }
        public ActionResult afterpagerender()
        {
            var scondtime = TempData["hello"];//now temp data value becomes null
         
            return View();
        }
    }
