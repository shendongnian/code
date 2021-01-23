    public class MyMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes, 
            Type containerType, 
            Func<object> modelAccessor, 
            Type modelType, 
            string propertyName
        )
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var engineer = attributes.OfType<EngineerAttribute>().FirstOrDefault();
            if (engineer != null)
            {
                metadata.AdditionalValues["IsFoo"] = engineer.IsFoo;
            }
            return metadata;
        }
    }
