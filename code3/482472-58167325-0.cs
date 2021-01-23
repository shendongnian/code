    public class RequiredGuidAttribute : ValidationAttribute
    {
        public RequiredGuidAttribute() => ErrorMessage = "{0} is required.";
        public override bool IsValid(object value)
            => value != null && value is Guid && !Guid.Empty.Equals(value);
    }
