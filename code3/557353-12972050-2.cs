    namespace dd
    {
        [Themed]
        public class AdministratorController : DefaultController
        {
            [CustomAuthorize]
            public ActionResult Index()
            {
                return View();
            }
    
            public ActionResult GetCityOptions()
            {
                return View();
            }
        }
    }
