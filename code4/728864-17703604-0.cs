    public class ConditionalRequiredAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormatString 
                       = "The {0} field is required.";
        private readonly string _dependentPropertyName;
        public ConditionalRequiredAttribute(string dependentPropertyName)
        {
            _dependentPropertyName = dependentPropertyName;
            ErrorMessage = DefaultErrorMessageFormatString;
        }
        protected override ValidationResult IsValid(
                    object item, 
                    ValidationContext validationContext)
        {
            var property = validationContext
                             .ObjectInstance.GetType()
                             .GetProperty(_dependentPropertyName);
            
            var dependentPropertyValue = 
                                property
                                .GetValue(validationContext.ObjectInstance, null);
            int value;
            if (dependentPropertyValue is bool 
                               && (bool)dependentPropertyValue)
            {
                /* Put the validations that you need here */
                if (item == null)
                {
                  return new ValidationResult(
                      string.Format(ErrorMessageString, 
                                    validationContext.DisplayName));
                }
            }
            
             return ValidationResult.Success;
        }
    }
