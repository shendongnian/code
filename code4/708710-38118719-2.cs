    public override ValidationResult Validate(ValidationContext<T> context)
    {
        return (context.InstanceToValidate == null) 
            ? new ValidationResult(new[] { new ValidationFailure("Property", "Error Message") })
            : base.Validate(context);		
    }
