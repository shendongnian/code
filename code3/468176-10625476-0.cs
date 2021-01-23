    protected override ValidationResult IsValid(object value, 
      ValidationContext validationContext)
    {
      var requiredAttribute = validationContext.ObjectType
        .GetPropery(validationContext.MemberName)
        .GetCustomAttributes(true).OfType<RequiredAttribute>().SingleOrDefault();
    }
