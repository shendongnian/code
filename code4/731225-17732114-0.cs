    var validator = new RestrictInputTypeValidator()
    validator.Restriction = MyRestrictionEnum.IntegersOnly;
    // Here for example our input is invalid.
    var result = validator.Validate("My Input", MyCulture);
    Assert.IsFalse(result.IsValid);
