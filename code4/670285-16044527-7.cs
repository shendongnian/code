    public class ViewModel
    {
        public int Value { get; set; }
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (!staticClass.IsRegistrationNumberValid(this.Value))
            {
                yield return new ValidationResult("An error occured");
            }
    }
