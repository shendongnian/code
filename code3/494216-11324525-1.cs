    public class DenyAnonymousAccessPolicyViolationHandler : IPolicyViolationHandler
	{
		public ActionResult Handle(PolicyViolationException exception)
		{
			var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));
			var areaName = routeData.GetAreaName();
			return
				new RedirectToRouteResult(
					new RouteValueDictionary(new { action = "AnonymousError", controller = "Error", area = areaName }));
		}
	}
