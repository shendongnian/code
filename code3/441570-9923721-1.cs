    public class CtsDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var extended = new ExtendedModelMetadata();
            PopulateMetadata(extended, attributes, containerType, modelAccessor, modelType, propertyName);
        
            return extended ;
        }
        protected override void PopulateMetadata(ModelMetaData data, IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
             base.PopulateMetaData(data, attributes, containerType, modelAccessor, modelType, propertyName);
            //populate extended properties.
        }
    }
