    public class MyValidationAttribute: ValidationAttribute
    {
       public MyValidationAttribute()
       { }
        protected override ValidationResult IsValid(
               object value, ValidationContext validationContext)
        {
            
            ...
            if (somethingWrong)
            {
                return new ValidationResult(errorMessage); 
            }
            return null; // everything OK
        }
    }
