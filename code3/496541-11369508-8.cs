    public class CustomModelMetaData : DataAnnotationsModelMetadata
    {
    	public CustomModelMetaData(DataAnnotationsModelMetadataProvider provider, Type containerType,	
    			Func<object> modelAccessor, Type modelType, string propertyName,			
    			DisplayColumnAttribute displayColumnAttribute) :			
    	base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
    	{
    	}
    
    	public override IEnumerable<ModelValidator> GetValidators(ControllerContext context)
    	{
    		if (context.HttpContext.Items["NoValidation"] != null && 
    		           bool.Parse(context.HttpContext.Items["NoValidation"].ToString()) == true)
    			return Enumerable.Empty<ModelValidator>();
    
    		return base.GetValidators(context);
    	}
    }
