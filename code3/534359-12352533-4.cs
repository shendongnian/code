    public class RequiredIfAttribute : ValidationAttribute
    {
        public RequiredIfAttribute(string otherProperty, object otherPropertyValue)
        {
            OtherProperty = otherProperty;
            OtherPropertyValue = otherPropertyValue;
        }
        public string OtherProperty { get; private set; }
        public object OtherPropertyValue { get; private set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(OtherProperty);
            if (property == null)
            {
                return new ValidationResult(string.Format("Unknown property: {0}", OtherProperty));
            }
            object otherPropertyValue = property.GetValue(validationContext.ObjectInstance, null);
            if (!object.Equals(OtherPropertyValue, otherPropertyValue))
            {
                return null;
            }
            if (value != null)
            {
                return null;
            }
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
    }
