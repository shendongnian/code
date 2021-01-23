    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MyValidationAttribute : ValidationAttribute
    {
        private readonly bool isRequired;
        public string Regex { get; set; }
        public int StringLength { get; set; }
        public MyValidationAttribute(bool isRequired)
        {
            this.isRequired = isRequired;
        }
        public override ValidationResult IsValid(object value)
        {
            var composedAttributes = ConstructAttributes().ToArray();
            if (composedAttributes.Length == 0) return ValidationResult.Success;
            var errorMsgBuilder = new StringBuilder();
            foreach (var attribute in composedAttributes)
            {
                if (!attribute.IsValid(value))
                    errorMsgBuilder.AppendLine(attribute.ErrorMessage);
            }
            var msg = errorMsgBuilder.ToString();
            if (string.IsNullOrWhiteSpace(msg))
                return ValidationResult.Success;
            return new ValidationResult(msg);
        }
        private IEnumerable<ValidationAttribute> ConstructAttributes()
        {
            if (isRequired)
                yield return new RequiredAttribute();
            if (Regex != null)
                yield return new RegularExpressionAttribute(Regex);
            if (StringLength > 0)
                yield return new StringLengthAttribute(StringLength);
        }
    }
