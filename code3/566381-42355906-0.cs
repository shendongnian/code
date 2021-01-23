    public override ValidationResult Validate(ValidationContext<FooBar> context)
    {
        var fooResult = new FooValidator().Validate(context.InstanceToValidate);
        var barResult = new BarValidator().Validate(context.InstanceToValidate);
        
        var errors = new List<ValidationFailure>();
        errors.AddRange(fooResult.Errors);
        errors.AddRange(barResult.Errors);
        return new ValidationResult(errors);
    }
