    public class CustomAttribute : ValidationAttribute
    {
        private readonly string _other;
        public CustomAttribute(string other)
        {
            _other = other;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_other);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format("Unknown property: {0}", _other)
                );
            }
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);
    
            // at this stage you have "value" and "otherValue" pointing
            // to the value of the property on which this attribute
            // is applied and the value of the other property respectively
            // => you could do some checks
            if (!object.Equals(value, otherValue))
            {
                // here we are verifying whether the 2 values are equal
                // but you could do any custom validation you like
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
    }
