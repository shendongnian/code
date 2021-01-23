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
            var itemKey = this.CreateKey(context.RouteData);
            if (context.HttpContext.Items[itemKey] != null && 
               bool.Parse(context.HttpContext.Items[itemKey].ToString()) == true)
            {
                 return Enumerable.Empty<ModelValidator>();
            }
            return base.GetValidators(context);
    	}
        private string CreateKey(RouteData routeData)
        {
           var action = (routeData.Values["action"] ?? null).ToString().ToLower();
           var controller = (routeData.Values["controller"] ?? null).ToString().ToLower();
           return string.Format("NoValidation_{0}_{1}", controller, action);
        }
    }
