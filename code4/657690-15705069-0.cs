    using System.Web.Mvc;
    namespace Test.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View("Index");
            } 
            public ActionResult Check()
            {
                // check if user is allowed to show secret page
                if(allowSecret == true)    
                    return View("Secret");
                // Otherwise return view 'index.cshtml' 
                return View();
            }
            public ActionResult Secret()
            {
                // Always shows view 'index.cshtml' if url is ".../secret"
                return View("Index");
            }        
        }
    }
