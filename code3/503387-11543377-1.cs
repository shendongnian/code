    public class ErrorController : Controller
    {
    	public ActionResult AccessDenied()
    	{
    		return View("AccessDenied");
    	}
    
    	public ActionResult InvalidRequest()
    	{
    		return View("InvalidRequest");
    	}
    
    	public ActionResult NotFound()
    	{
    		return View("NotFound");
    	}
    
    	public ActionResult ServerError()
    	{
    		return View("ServerError");
    	}
    }
