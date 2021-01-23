    public override ValidationResult Validate(ValidationContext<T> context)
    {
        return (context.InstanceToValidate == null) 
            ? throw new ValidationResult(new[] { new ValidationFailure("Property", "Error Message") })
            : base.Validate(context);		
    }
