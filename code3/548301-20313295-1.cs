    public class EmptyStringDataAnnotationsModelMetadataProvider : System.Web.Mvc.DataAnnotationsModelMetadataProvider 
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var modelMetadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            modelMetadata.ConvertEmptyStringToNull = false;
            return modelMetadata;
        }
    }
