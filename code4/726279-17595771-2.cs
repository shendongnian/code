    public class TemplateNameModel : IValidatableObject
    {
        //definition of the class
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // check for conditions here
            yield return new ValidationResult("Validation message.");
        }
    }
