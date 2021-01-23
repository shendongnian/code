    public class DashFormValueProvider : NameValueCollectionValueProvider
    {
    	public DashFormValueProvider(ControllerContext controllerContext)
    	: base(controllerContext.HttpContext.Request.Form, 
    	controllerContext.HttpContext.Request.Unvalidated().Form, 
    	CultureInfo.CurrentCulture)
    	{
    	}
    
    	public override bool ContainsPrefix(string prefix)
    	{
    		return base.ContainsPrefix(GetModifiedPrefix(prefix));
    	}
    
    	public override ValueProviderResult GetValue(string key)
    	{
    		return base.GetValue(GetModifiedPrefix(key));
    	}
    
    	public override ValueProviderResult GetValue(string key, bool skipValidation)
    	{
     		return base.GetValue(GetModifiedPrefix(key), skipValidation);
    	}
    
        // this will convert the key "FirstName" to "first-name".
    	private string GetModifiedPrefix(string prefix)
    	{
    		return Regex.Replace(prefix, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1-").ToLower();
    	}
    }
