    public override IEnumerable<ValidationResult> Validate(ValidationContext vc)
    {
        List<ValidationResult> retVal = new List<ValidationResult>();
        Validator.TryValidateObject(this, vc, retVal, true);
        foreach (var item in retVal) {
            yield return item;
        }
    
        if (Name == "Arbitary")
            yield return new ValidationResult("Bad Name.", new[] { "Name" });
        else if (Email == "BadEmail")
            yield return new ValidationResult("Bad Email.", new[] { "Email" });
        //...
    }
