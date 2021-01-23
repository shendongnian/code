    public class MinAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           // Do some validation checks here
            var result = ValidationResult.Success;
            return result;
        }
