	public class YourNotFoundHandler : IServiceStackHttpHandler, IHttpHandler
	{
		public void ProcessRequest(IHttpRequest request, IHttpResponse response, string operationName)
		{ ... }
		
		public void ProcessRequest(HttpContext context)
		{ ... }
	}
