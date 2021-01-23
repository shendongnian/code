    public class NotAllowedIfNotNullAttribute<T> : ValidationAttribute, IClientValidatable
        {
            private readonly RequiredAttribute _innerAttribute = new RequiredAttribute();
    
            public string DependentProperty { get; set; }
            public T NotAllowedValue { get; set; }
    
            public NotAllowedIfNotNullAttribute(string dependentProperty, T notAllowedValue)
            {
                DependentProperty = dependentProperty;
                NotAllowedValue = notAllowedValue;
            }
    
            protected override ValidationResult IsValid(T value, ValidationContext validationContext)
    ...
