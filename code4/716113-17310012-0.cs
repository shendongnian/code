    public class BaseController: Controller
    {
    	protected void LogInfo()
    	{ ... }
    	
    	virtual public ActionResult Index(string name)
    	{
    		LogInfo();
    		getQueryString();
    		.....
    		
    		var viewname = getViewName(name);
    		return view(viewname);
    	}
    }
    
    public class FirstController : BaseController
    {
    	override public ActionResult Index(string name)
    	{
    			var result = base.Index(name);
    			.... do more stuff ...
    			return result;
    	}
    }
    
    public class SecondController : BaseController
    {
    	// Don't need to override index if you 
    	// want to do the same as in the base controller
    }
