    public class MyMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            // TODO: you could keep a static hashtable that will map between your
            // domain model type and the associated metadata type in your UI layer
            // but for the purpose of this demonstration I have hardcoded them to simplify
            if (containerType == typeof(MyDomainModel))
            {
                return GetMetadataForProperty(
                    modelAccessor, 
                    typeof(MyDomainModelMetadata), 
                    propertyName
                );
            }
            return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
        }
    }
