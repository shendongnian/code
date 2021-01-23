	using System;
	
	namespace Sample
	{
		[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
		public class SampleFilter : ActionFilterAttribute
		{
			public override void OnActionExecuted(ActionExecutedContext filterContext)
			{
	
				base.OnActionExecuted(filterContext);
			}
		}
	}
