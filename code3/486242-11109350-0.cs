    public class EnsureSslModule : IHttpModule
    {
    	private static readonly string[] _pagesToEnsure = new[] { "login.aspx", "register.aspx" };
    
    	public void Dispose()
    	{
    	}
    	
    	public void Init(HttpApplication context)
    	{
    		context.BeginRequest += OnBeginRequest;
    	}
    	
    	public void OnBeginRequest(object sender, EventArgs e)
    	{
    		var application = (HttpApplication)sender;
    		var context = application.Context;
    		
    		var url = context.Request.RawUrl;
    		
    		if (!context.Request.IsSecureConnection 
    				&& _pagesToEnsure.Any(page => url.IndexOf(page, StringComparison.InvariantCultureIgnoreCase) > -1))
    		{
    			var builder = new UriBuilder(url);
    			
    			builder.Scheme = Uri.UriSchemeHttps;
    			
    			context.Response.Redirect(builder.Uri.ToString(), true);
    		}
    	}
    }
