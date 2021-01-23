       public class MyCustomValidationAttribute : ValidationAttribute, IMetadataAware
        {
            private readonly object _typeId = new object();
            private ModelMetadata _metadata;
    
            public MyCustomValidationAttribute()
            {
            }
    
            public override object TypeId
            {
                get
                {
                    return _typeId;
                }
            }
    
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                //Do something with the meta data
                string propertyName = _metadata.PropertyName;
                
                return ValidationResult.Success;
            }
    
            public void OnMetadataCreated(ModelMetadata metadata)
            {
                _metadata = metadata;         
            }
        }
