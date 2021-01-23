    [AttributeUsage(AttributeTargets.Property]
    public class CustomRequiredPhone : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = null;
            // Check if Model is WorkphoneViewModel, if so, activate validation
            if (validationContext.ObjectInstance.GetType() == typeof(WorkPhoneViewModel)
             && string.IsNullOrWhiteSpace((string)value) == true)
            {
                this.ErrorMessage = "Phone is required";
                validationResult = new ValidationResult(this.ErrorMessage);
            }
            else
            {
                validationResult = ValidationResult.Success;
            }
            return validationResult;
        }
    }
