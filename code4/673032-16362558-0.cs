    public class PersonDetails : IValidatableObject
    {
        public string Name { get; set; }
        public Phone PhoneDetails { get; set; }
        public string Address { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PhoneDetails.MobilePhone == 0 && PhoneDetails.WorkPhone == 0 && PhoneDetails.HomePhone == 0)
                yield return new ValidationResult("Please enter at least 1 phone number", new[] { "PhoneDetails" });
        }
    }
