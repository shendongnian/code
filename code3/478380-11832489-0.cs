    public class Popup : ActionFilterAttribute
    {
    	public override void OnActionExecuted(ActionExecutedContext filterContext)
    	{
    		if (filterContext.Result != null
    			&& filterContext.Result is ViewResult
    			&& filterContext.RequestContext.HttpContext.Request["popup"] == "true")
    			(filterContext.Result as ViewResult).MasterName = "~/Views/Shared/_PopupLayout.cshtml";
    	}
    }
