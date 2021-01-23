    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
     {
        if (validationContext["Prop1"] == validationContext["Prop2"])
        {
            yield return new ValidationResult(
                  "Prop1 and Prop2 must be different.",
                  new[] {"Prop1", "Prop2"});
        }
     }
