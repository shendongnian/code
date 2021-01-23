    public class CustomRequiredAttribute : RequiredAttribute, IClientValidatable
        {
            public override string FormatErrorMessage(string name)
            {
                return String.Format(ErrorMessages.FieldRequired, name);
            } 
    
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                var rule = new ModelClientValidationRequiredRule(String.Format(ErrorMessages.FieldRequired, metadata.DisplayName));
                return new[] { rule };
            }
        }
