    public class LessThanOrEqualToFluentValidationPropertyValidator : FluentValidationPropertyValidator
    {
        public LessThanOrEqualToFluentValidationPropertyValidator(ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator)
        {
        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!this.ShouldGenerateClientSideRules())
            {
                yield break;
            }
            var validator = Validator as LessThanOrEqualValidator;
            var errorMessage = new MessageFormatter()
                .AppendPropertyName(this.Rule.GetDisplayName())
                .BuildMessage(validator.ErrorMessageSource.GetString());
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = errorMessage,
                ValidationType = "lessthanorequaldate"
            };
            rule.ValidationParameters["other"] = CompareAttribute.FormatPropertyForClientValidation(validator.MemberToCompare.Name);
            yield return rule;
        }
    }
