    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class RequiredIfAttribute : RequiredAttribute
    {
        private string OtherProperty { get; set; }
        private object Condition { get; set; }
        public RequiredIfAttribute(string otherProperty, object condition)
        {
            OtherProperty = otherProperty;
            Condition = condition;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(OtherProperty);
            if (property == null)
                return new ValidationResult(String.Format("Property {0} not found.", OtherProperty));
            var propertyValue = property.GetValue(validationContext.ObjectInstance, null);
            var conditionIsMet = Equals(propertyValue, Condition);
            return conditionIsMet ? base.IsValid(value, validationContext) : null;
        }
    }
