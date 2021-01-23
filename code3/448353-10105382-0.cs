    public override IEnumerable<ValidationResult> Validate(ValidationContext vc)
    {
        // TryValidateObject fills the ICollection you pass it.
        List<ValidationResult> retVal = new List<ValidationResult>();
        Validator.TryValidateObject(this, vc, retVal, true);
        foreach (var item in retVal)
            yield return item;
        if (Name == "Arbitary")
            yield return new ValidationResult("Bad Name.", new[] { "Name" });
        else if (Email == "BadEmail")
            yield return new ValidationResult("Bad Email.", new[] { "Email" });
        else
           if (retVal.Count == 0)
              yield break;
    }
