    public class ValidateEmailIfAttribute : ValidationAttribute, IClientValidatable
    {
      private ValidateEmailAttribute _innerAttribute = new ValidateEmailAttribute();
    
      public string DependentProperty { get; set; }
      public object TargetValue { get; set; }
    
      public ValidateEmailIfAttribute(string dependentProperty, object targetValue)
      {
        this.DependentProperty = dependentProperty;
        this.TargetValue = targetValue;
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
              (dependentvalue != null && dependentvalue.Equals(this.TargetValue)))
          {
            // match => means we should try validating this field
            if (!_innerAttribute.IsValid(value))
              // validation failed - return an error
              return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
          }
        }
    
        return ValidationResult.Success;
      }
    
      // Client-side validation code omitted for brevity
    }
