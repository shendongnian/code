    [SelfValidation]
    public void Validation(ValidationResults results)
    {
        if (!Utility.IsValidEmailAddress(this.BillingEmailAddress))
        {
            results.AddResult(new ValidationResult(Constants.ERROR_INVALID_EMAILADDRESS, this, "", "", null));
        }
    }
