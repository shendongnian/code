    public class ErrorHandlerController : Controller
        {
            
            public ActionResult Index(string strErrMsg)
            {
                ViewBag.Exception = strErrMsg;
                return View();
            }
    
        }
