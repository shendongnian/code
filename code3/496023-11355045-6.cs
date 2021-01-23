    public class UrlHandlerController : Controller
    {
        [HttpGet]
        public ActionResult Process(string url)
        {
            return View();
    
            /* or */
            if(url == "something"){
                return View("SomethingView");
            }
            else if(url == "somethingelse"){
                return View("SomethingElseView");
            }
        }
    
    }
