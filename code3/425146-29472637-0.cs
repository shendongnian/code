	namespace My.Application.Namespace
	{
		public class CustomWebModule : IHttpModule
		{
			static void AuthenticateRequest(object sender, EventArgs e){
				// DO ALL FANCY STUFF in my app and then make calls to the 
				// KEY umbraco functions from umbraco.core.security.AuthenticationExtensions 
				// "AuthenticateCurrentRequest" function.
				// 
				// specifically: setting the GenericPrincipal and related entities.
			}
			public void Dispose()
			{
				//throw new NotImplementedException();
				// make sure you don't write a memory leak!
				// dispose of everything that needs it!
			}
			public void Init(HttpApplication app)
			{
				app.AuthenticateRequest += AuthenticateRequest;	
			}
		}
	}
