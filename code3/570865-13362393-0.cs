    public abstract class WarningAttribute : ValidationAttribute, IClientValidatable
    {
        protected abstract ValidationAttribute Validator { get; }
        protected abstract Type AdapterType { get; }
    
        protected virtual ValidationResult IsValid(object value, ValidationContext validationContext)
        {
          return Validator.GetValidationResult(value, validationContext);
        }
    
        public virtual IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
          if (AdapterType != null)
          {
            var rule = ((DataAnnotationsModelValidator)Activator.CreateInstance(AdapterType, metadata, context, Validator)).GetClientValidationRules().FirstOrDefault();
            rule.ValidationType = String.Format("{0}-warning", rule.ValidationType);
            return new[] { rule };
          }
    
          return Enumerable.Empty<ModelClientValidationRule>();
        }
    }
