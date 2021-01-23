     public class AlphaSpaceAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public AlphaSpaceAttribute()
            : base(@"^([a-zA-Z ]*)\s*")
        {
        }
        public override string FormatErrorMessage(string name)
        {
            return Resources.UDynamics.EM_10003;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(this.ErrorMessage),
                ValidationType = "regex",
            };
            rule.ValidationParameters.Add("pattern", @"^([a-zA-Z ]*)\s*");
            yield return rule;
        }
    }
