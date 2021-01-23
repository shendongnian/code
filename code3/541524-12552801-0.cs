    public class MyValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var testProperty = (TestProperty)value;
            if (testProperty == null || string.IsNullOrEmpty(testProperty.Name))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
    }
