     public class PrototypeWebValidatorExtension : PrototypeWebValidator
    {
        public new IBrowserValidationGenerator CreateGenerator(BrowserValidationConfiguration config, InputElementType inputType, IDictionary attributes)
        {
            return new PrototypeValidationGeneratorExtension((PrototypeWebValidator.PrototypeValidationConfiguration)config, inputType, attributes);
        }
    }
