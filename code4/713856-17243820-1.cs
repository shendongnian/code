    public class ValidValuesAttribute: ValidationAttribute
    {
      string[] _args;
    
      public ValidValuesAttribute(params string[] args)
      {
        _args = args;
      }
    
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
        if (_args.Contains((string)value))
          return ValidationResult.Success;
        return new ValidationResult("Invalid value.");
      }
    }
