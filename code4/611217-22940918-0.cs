    public class MyControllerForAuthorizedStuff
    {
        [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
        public ActionResult Index()
        {
            return View();
        }
    } 
