    public class RollType : ValidationAttribute
    {
       public override ValidationResult IsValid(object value, ValidationContext validationContext)
       {
          return new ValidationResult("Something went wrong");
       }
    }
