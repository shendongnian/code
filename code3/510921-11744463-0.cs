    public enum RequestAcceptType
    {
    	NotSpecified,
    	Json,
    	Xml
    }
    
    public class RequestAcceptTypeModelBinder : IModelBinder
    {
    	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    	{
    		if (bindingContext == null)
    		{
    			throw new ArgumentNullException("bindingContext");
    		}
    
    		RequestAcceptType acceptType = RequestAcceptType.NotSpecified;
    
    		// Try for Json
    		if (controllerContext.HttpContext.Request.AcceptTypes.Contains("application/json") || controllerContext.HttpContext.Request.Url.Query.Contains("application/json"))
    		{
    			acceptType = RequestAcceptType.Json;
    		}
    
    		// Default to Xml
    		if (acceptType == RequestAcceptType.NotSpecified)
    		{
    			acceptType = RequestAcceptType.Xml;
    		}
    
    		return acceptType;
    	}
    }
