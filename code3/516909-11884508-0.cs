    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var errorMessages = new List<string>() { "test", "test2" };
            RouteValueDictionary rvd = new RouteValueDictionary()
            {
                { "controller", "home" },
                { "action", "action" }
            };
            for (int i = 0; i < errorMessages.Count; i++)
                rvd["errorMessages[" + i + "]"] = errorMessages[i];
            return RedirectToRoute("Default", rvd);
        }
        public ActionResult Action(List<string> errorMessages)
        {
            // Do stuff
            return View();
        }
    }
