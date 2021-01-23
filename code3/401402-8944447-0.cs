    public class PrototypeValidationGeneratorExtension : PrototypeWebValidator.PrototypeValidationGenerator
    {
        private PrototypeWebValidator.PrototypeValidationConfiguration _config;
        public PrototypeValidationGeneratorExtension(PrototypeWebValidator.PrototypeValidationConfiguration config, InputElementType inputType, IDictionary attributes)
            :base(config,inputType,attributes)
        {
            _config = config;
        }
        public new void SetValueRange(string target, int minValue, int maxValue, string violationMessage)
        {
                        this._config.AddCustomRule("validate-range",violationMessage,string.Format("min : {0}, max : {1}", minValue, maxValue));
        }
    }
