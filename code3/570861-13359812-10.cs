    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class StringLengthWarningAttribute : ValidationAttribute, IClientValidatable 
    {
        public int MaximumLength { get; set; }
        public override bool IsValid(object value)
        {
            return true;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as BaseViewModel;
            var str = value as string;
            if (!model.IgnoreWarnings && (string.IsNullOrWhiteSpace(str) || str.Length > MaximumLength))
                return new ValidationResult(ErrorMessage);
            return base.IsValid(value, validationContext);
        }
        
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new StringLengthWarningValidationRule(MaximumLength, ErrorMessage);
        }
    }
