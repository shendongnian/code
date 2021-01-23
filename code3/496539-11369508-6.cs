    public class CustomModelMetaDataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(System.Collections.Generic.IEnumerable<Attribute> attributes,
          Type containerType, Func<object> modelAccessor,
          Type modelType,
          string propertyName)
        {
          return new CustomModelMetaData(this, containerType, modelAccessor, modelType, 
             propertyName); 
        }
    }
