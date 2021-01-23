    public class DecimalMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
    
            if (propertyName == null)
                return metadata;
    
            if (metadata.ModelType == typeof(decimal))
            {
                // Given DisplayFormat Attribute:
    
                // if ApplyFormatInEditMode = true 
                // metadata.EditFormatString = "{0:0.00}";
    
                // for DataFormatString
                metadata.DisplayFormatString = "{0:0.00}";
    
                // for ConvertEmptyStringToNull
                metadata.ConvertEmptyStringToNull = false;
            }
    
            return metadata;
        }
    }
