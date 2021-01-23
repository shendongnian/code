    class MyObject {
        [NonZero]
        public decimal Amount { get; set; }
    }
    public class NonZeroAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0} must be non-zero", name);
        }
        public override bool IsValid(object value)
        {
            var zero = Convert.ChangeType(0, value.GetType());
            return !zero.Equals(value);
        }
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (IsValid(value))
                return new ValidationResult(null);
            else
                return new ValidationResult(
                    FormatErrorMessage(validationContext.MemberName)
                );
        }
    }
