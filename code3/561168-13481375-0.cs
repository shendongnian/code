    public class LoginRequired : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (Common.ValidateCurrentSession(filterContext.HttpContext))
			{
				//this is valid; keep going
				return;
			}
			else
			{
				//this is not valid; redirect
				filterContext.Result = new RedirectResult("/login");
			}
		}
	}
