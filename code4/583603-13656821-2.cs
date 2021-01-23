	public class DenyAnonymousAccessPolicyViolationHandler : IPolicyViolationHandler
	{
		public ActionResult Handle(PolicyViolationException exception)
		{
			//Log the violation, send mail etc. etc.
			var rvd = new RouteValueDictionary(new
			{
				area = "",
				controller = "Account",
				action = "LogOn",
				statusDescription = exception.Message
			});
			return new RedirectToRouteResult(rvd);
		   
		}
	}
