    // System.Web.Mvc.JsonValueProviderFactory
    private static object GetDeserializedObject(ControllerContext controllerContext)
    {
    	if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
    	{
    		return null;
    	}
    	StreamReader streamReader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
    	string text = streamReader.ReadToEnd();
    	if (string.IsNullOrEmpty(text))
    	{
    		return null;
    	}
    	JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
    	return javaScriptSerializer.DeserializeObject(text);
    }
