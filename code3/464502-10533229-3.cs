    public class ConditionalRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        private RequiredAttribute _innerAttribute = new RequiredAttribute();
        private readonly string _fieldProperty;
        public ConditionalRequiredAttribute(string fieldProperty)
        {
            _fieldProperty = fieldProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(_fieldProperty);
            if (field == null)
            {
                return new ValidationResult(string.Format("Unknown property {0}", _fieldProperty));
            }
            var fieldValue = (Field)field.GetValue(validationContext.ObjectInstance, null);
            if (fieldValue == null)
            {
                return new ValidationResult(string.Format("The property {0} was null", _fieldProperty));
            }
            if (fieldValue.IsRequired && !_innerAttribute.IsValid(value))
            {
                return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
            }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "conditionalrequired",
            };
            rule.ValidationParameters.Add("iserquiredproperty", _fieldProperty + ".IsRequired");
            yield return rule;
        }
    }
