    public class RequiredIfTrueAttribute: ValidationAttributeBase
    {
        public string DependentPropertyName { get; private set; }
        public RequiredIfTrueAttribute(string dependentPropertyName) 
            : base()
        {
                this.DependentPropertyName = dependentPropertyName;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the property we need to see if we need to perform validation
            PropertyInfo property = validationContext.ObjectType.GetProperty(this.DependentPropertyName);
            object propertyValue = property.GetValue(validationContext.ObjectInstance, null);
            // ... logic specific to my attribute
            return ValidationResult.Success;
        }
    }
