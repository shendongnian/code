  public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var context = new ValidationContext(this.Details, validationContext.ServiceContainer, validationContext.Items);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(this.Details, context, results);
        return results;
    }
