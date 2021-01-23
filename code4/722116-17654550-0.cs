    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        ModelClientValidationRule rule = new ModelClientValidationRule();
        rule.ErrorMessage = ErrorMessages.ClientFieldInputValidation;
        rule.ValidationType = "regex";
        rule.ValidationParameters.Add("pattern", _regEx);
        yield return rule;
    }
