    public class GlobalErrorHandler
    {
    	public static void HandleError(HttpContext context, Exception ex, Controller controller)
    	{
    		LogException(ex);
    
    		context.Response.StatusCode = GetStatusCode(ex);
    		context.ClearError();
    		context.Response.Clear();
    		context.Response.TrySkipIisCustomErrors = true;
    
    		if (IsAjaxRequest(context.Request))
    		{
    			ReturnErrorJson(context, ex);
    			return;
    		}
    
    		ReturnErrorView(context, ex, controller);
    	}
    
    	public static void LogException(Exception ex)
    	{
    		// log the exception
    	}
    
    	private static void ReturnErrorView(HttpContext context, Exception ex, Controller controller)
    	{
    		var routeData = new RouteData();
    		routeData.Values["controller"] = "Error";
    		routeData.Values["action"] = GetActionName(GetStatusCode(ex));
    
    		controller.ViewData.Model = new HandleErrorInfo(ex, " ", " ");
    		((IController)controller).Execute(new RequestContext(new HttpContextWrapper(context), routeData));
    	}
    
    	private static void ReturnErrorJson(HttpContext context, Exception ex)
    	{
    		var json = string.Format(@"success: false, error:""{0}""", ex.Message);
    		context.Response.ContentType = "application/json";
    		context.Response.Write("{" + json + "}");
    	}
    
    	private static int GetStatusCode(Exception ex)
    	{
    		return ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
    	}
    
    	private static bool IsAjaxRequest(HttpRequest request)
    	{
    		return request.Headers["X-Requested-With"] != null && request.Headers["X-Requested-With"] == "XMLHttpRequest";
    	}
    
    	private static string GetActionName(int statusCode)
    	{
    		string actionName;
    
    		switch (statusCode)
    		{
    			case 404:
    				actionName = "NotFound";
    				break;
    
    			case 400:
    				actionName = "InvalidRequest";
    				break;
    
    			case 401:
    				actionName = "AccessDenied";
    				break;
    
    			default:
    				actionName = "ServerError";
    				break;
    		}
    
    		return actionName;
    	}
    
    	public static bool IsDebug
    	{
    		get
    		{
    			bool debug = false;
    
    #if DEBUG
    			debug = true;
    #endif
    			return debug;
    		}
    	}
    }
