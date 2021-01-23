    public class DatabaseActionFilter : ActionFilterAttribute
    {
    	public override void OnActionExecuted(ActionExecutedContext filterContext)
    	{
    		var result = filterContext.Result;
    
    		var model = result.ViewData.Model;
    	}
    }
