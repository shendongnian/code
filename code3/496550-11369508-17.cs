    public class CustomModelMetaData : ModelMetadata
    {
        public CustomModelMetaData(ModelMetadataProvider provider, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName) :
          base(provider, containerType, modelAccessor, modelType, propertyName)
        {
        }
    
        public override System.Collections.Generic.IEnumerable<ModelValidator> GetValidators(ControllerContext context)
        {
          if (context.HttpContext.Items["NoValidation"] != null && bool.Parse(context.HttpContext.Items["NoValidation"].ToString()) == true)
            return Enumerable.Empty<ModelValidator>();
    
          return base.GetValidators(context);
        }
    }
