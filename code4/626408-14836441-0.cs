    using System.ComponentModel.DataAnnotations;
    public class testattribute : ValidationAttribute    
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
