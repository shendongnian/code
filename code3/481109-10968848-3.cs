    public class LogAction : IHttpHandler
    {
    	public void ProcessRequest(HttpContext context)
    	{
                    // log here what you wish
    
                    // end up with no content
    		context.Response.TrySkipIisCustomErrors = true;
    		context.Response.Status = "204 No Content";
    		context.Response.StatusCode = 204;    		
    	}
    }
