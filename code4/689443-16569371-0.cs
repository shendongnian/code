    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ErrorMessage = this.ErrorMessage,
            ValidationType = "userage",
        };
        rule.ValidationParameters.Add("minAge", ConfigurationManager.AppSettings["MinAge"]);
        yield return rule;
    }
