    public override IEnumerable<ValidationResult> Validate(ValidationContext vc)
    {
      return ResultsFromValidator(vc).Concat(AdditionalResults());
    }
    private IEnumerable<ValidationResult> ResultsFromValidator(ValidationContext vc)
    {
      List<ValidationResult> retVal = new List<ValidationResult>();
      Validator.TryValidateObject(this, vc, retVal, true);
      return retVal;
    }
    private IEnumerable<ValidationResult> AdditionalResults()
    {
      if (Name == "Arbitrary")
        yield return new ValidationResult("Bad Name.", new[] { "Name" });
      ...
    }
