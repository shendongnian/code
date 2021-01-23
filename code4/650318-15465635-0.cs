    public class CustomValidationAttribute : ValidationAttribute
    {
        public string MeaningfulValidationInfo { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // do whatever meaningful with MeaningfulValidationInfo 
            return base.IsValid(value, validationContext);
        }
    }
