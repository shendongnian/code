    public class ExtendedControllerFactory:DefaultControllerFactory
	{
		public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
		{
		    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(GetCultureFromURLOrAnythingElse());
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureFromURLOrAnythingElse());
			return base.CreateController(requestContext, controllerName);
		}
		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
		    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(GetCultureFromURLOrAnythingElse());
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GetCultureFromURLOrAnythingElse());
			return base.GetControllerInstance(requestContext, controllerType);
		}
