	public class MyAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
	{
		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			return actionContext.Request.RequestUri.IsLoopback || base.IsAuthorized(actionContext);
		}
	}
