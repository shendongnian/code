    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited=true)]
    public class SmallerThanAttribute : ValidationAttribute
    {
        public SmallerThanAttribute(string otherPropertyName)
        {
            this.OtherPropertyName = otherPropertyName;
        }
        public string OtherPropertyName { get; set; }
        public string OtherPropertyDisplayName { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return IsValid(OtherPropertyName, value, validationContext);
        }
        private ValidationResult IsValid(string otherProperty, object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(otherProperty);
            
            if (otherPropertyInfo == null)
            {
                throw new Exception("Could not find property: " + otherProperty);
            }
            var displayAttribute = otherPropertyInfo.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
            if (displayAttribute != null && OtherPropertyDisplayName == null)
            {
                OtherPropertyDisplayName = displayAttribute.GetName();
            }
            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            var smaller = (IComparable) value;
            var bigger = (IComparable) otherPropertyValue;
            if (smaller == null || bigger == null)
            {
                return null;
            }
            
            if (smaller.CompareTo(bigger) > 0)
            {
                return new ValidationResult(string.Format(ValidatorResource.SmallerThan, validationContext.DisplayName, OtherPropertyDisplayName));
            }
            return null;
        }
    }
