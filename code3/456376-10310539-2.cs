    public class RollType : ValidationAttribute
    {
       protected override ValidationResult IsValid(object value, ValidationContext validationContext)
       {
          return new ValidationResult("Something went wrong");
       }
    }
