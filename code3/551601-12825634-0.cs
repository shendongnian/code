    public class GreaterThanOtherAttribute : ValidationAttribute, IClientValidatable
    {
        public string DependentProperty { get; set; }
        
        public GreaterThanOtherAttribute (string dependentProperty)
        {
            this.DependentProperty = dependentProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // get a reference to the property this validation depends upon
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(this.DependentProperty);
            if (field != null)
            {
                // get the value of the dependent property
                var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);
                // compare the value against the target value
                if ((dependentvalue == null && this.TargetValue == null) ||
                    (dependentvalue != null && dependentvalue < this.TargetValue)))
                {
                    // match => means we should try validating this field
                    return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
                }
            }
            return ValidationResult.Success;
        }
