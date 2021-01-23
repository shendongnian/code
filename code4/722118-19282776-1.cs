    public class OneDigitAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public OneDigitAttribute()
            : base(@"^.*(?=.*\d).+$")
        {
            ErrorMessage = "Required at least one numeric digit";
        }
        // for supporting a client-side validation through jquery.validation.unobtrusive
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "onedigit"
            };
        }
    }
    
    public class OneAlphaAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public OneAlphaAttribute()
            : base(@"^.*(?=.*[a-zA-Z]).+$")
        {
            ErrorMessage = "Required at least one alphabet character";
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "onealpha"
            };
        }
    }
    public class OneSpecialCharacterAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public OneSpecialCharacterAttribute()
            : base(@"^.*(?=.*[^a-zA-Z0-9]).+$")
        {
            ErrorMessage = "Required at least one non alphabet numeric(special) character";
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "onespecial"
            };
        }
    }
