	[AttributeUsage(AttributeTargets.Method)]
	public class KendoGridAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			foreach (var sataSourceRequest in filterContext.ActionParameters.Values.Cast<DataSourceRequest>())
			{
				sataSourceRequest.Deflatten();
			}
		}
	}
