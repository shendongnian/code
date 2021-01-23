	public class CustomAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			int userId = (int)filterContext.ActionParameters["userId"];
		}
	}
