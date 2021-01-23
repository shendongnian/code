    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
        if (String.IsNullOrWhiteSpace(FirstName) && String.IsNullOrWhiteSpace(LastName))
        {
            yield return new ValidationResult("A name must be entered.", new string[] { "FirstName", "LastName" });
        }
    }
