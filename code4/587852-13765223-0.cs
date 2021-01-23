    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.RentDate > this.ReturnDate)
        {
            yield return new ValidationResult("Rent date must be prior to return date", new[] { "RentDate" });
        }
    }
