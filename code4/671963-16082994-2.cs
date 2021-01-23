    public class MyViewModel: IValidatableObject
    {   
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (regexFails)
            {
                results.Add(new ValidationResult("Please enter valid name."));
            }
        }
    }
