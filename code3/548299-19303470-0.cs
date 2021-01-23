    public class CustomModelBinder : DefaultModelBinder
    {
    	public bool ConvertEmptyStringToNull { get; set; }
    
    	public CustomModelBinder ()
    	{
    	}
    
    	public CustomModelBinder (bool convertEmptyStringToNull)
    	{
    		this.ConvertEmptyStringToNull = convertEmptyStringToNull;
    	}
    
    	protected override bool OnModelUpdating(ControllerContext controllerContext, ModelBindingContext bindingContext)
    	{
    		// this little bit is required to override the ConvertEmptyStringToNull functionality that we do not want!
    	
    		foreach (string propertyKey in bindingContext.PropertyMetadata.Keys)
    		{
    			if(bindingContext.PropertyMetadata[propertyKey] != null)
    					bindingContext.PropertyMetadata[propertyKey].ConvertEmptyStringToNull = this.ConvertEmptyStringToNull;
    		}
    		return base.OnModelUpdating(controllerContext, bindingContext);
    	}
    
    
    }
