    public class RequestLogModule : IHttpModule
    {
    	private HttpApplication _application;
    
    	public void Dispose()
    	{
    	}
    
    	public void Init(HttpApplication context)
    	{
    		_application = context;
    		_application.BeginRequest += ContextBeginRequest;
    	}
    
    	private void ContextBeginRequest(object sender, EventArgs e)
    	{
    		var request = _application.Request;
    
    		var bytes = new byte[request.InputStream.Length];
    		request.InputStream.Read(bytes, 0, bytes.Length);
    		request.InputStream.Position = 0;
    		string content = Encoding.UTF8.GetString(bytes);
    
    		Logger.LogRequest(
    			request.UrlReferrer == null ? "" : request.UrlReferrer.AbsoluteUri,
    			request.Url.AbsoluteUri,
    			request.UserAgent,
    			request.UserHostAddress,
    			request.UserHostName,
    			request.UserLanguages == null ? "" : request.UserLanguages.Aggregate((a, b) => a + "," + b),
    			request.ContentType,
    			request.HttpMethod,
    			content
    		);
    	}
    }
