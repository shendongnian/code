    public class BeforeEndDateAttribute : ValidationAttribute{
        public string EndDatePropertyName { get; set; }
        public string StartDate { get; set; }
    
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo endDateProperty = validationContext.ObjectType.GetProperty(EndDatePropertyName);
    
            DateTime endDate = (DateTime) endDateProperty.GetValue(validationContext.ObjectInstance, null);
    
            var startDate = DateTime.Parse(StartDate);
    
            // Do comparison
            // return ValidationResult.Success; // if success
            return new ValidationResult("Error"); // if fail
        }
    
    }
