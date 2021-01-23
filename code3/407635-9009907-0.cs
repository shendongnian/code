    public class BaseController : System.Web.Mvc.Controller
    {
    	public BaseController()
    	{
    	}
    	protected override System.Web.Mvc.IActionInvoker CreateActionInvoker()
    	{
            // Call Custom Code Here
    
    	    return base.CreateActionInvoker();
    
    	}
    }
