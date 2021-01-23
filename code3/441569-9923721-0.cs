    public class CtsDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var extended = new ExtendedModelMetadata();
            PopulateMetadata(extended);
        
            return extended ;
        }
        protected override void PopulateMetadata(ModelMetaData data, IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
             base.PopulateMetaData(extended, attributes, containerType, modelAccessor, modelType, propertyName);
            //populate extended properties.
        }
    }
