    [AttributeUsage(AttributeTargets.Property)]
        public class DateCorrectRangeAttribute : ValidationAttribute
        {
            public bool ValidateStartDate { get; set; }
            public bool ValidateEndDate { get; set; }
    
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var model = validationContext.ObjectInstance as YourModelType;
    
                if (model != null)
                {
                    if (model.StartDate > model.EndDate && ValidateEndDate
                        || model.StartDate > DateTime.Now.Date && ValidateStartDate)
                    {
                        return new ValidationResult(string.Empty);
                    }
                }
    
                return ValidationResult.Success;
            }
        }
    
