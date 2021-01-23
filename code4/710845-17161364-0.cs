    public class LastFourDigitsAttribute : ValidationAttribute, IClientValidatable
    {
        private string panPropertyname;
        public LastFourDigitsAttribute(string pan)
            : base()
        {
            if (string.IsNullOrEmpty(pan))
            {
                throw new ArgumentNullException("pan");
            }
            this.panPropertyname = pan;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage,
                // This is the name of the method added to the jQuery validator method (must be lower case)
                ValidationType = "lastfour"
            };
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo panPropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(panPropertyname);
                if (panPropertyInfo != null)
                {
                    var panPropertyValue = panPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                    if (panPropertyValue != null)
                    {
                        if (value.ToString() != panPropertyValue.ToString().Substring(panPropertyValue.ToString().Length - 4);)
                        {
                            return new ValidationResult(ErrorMessage);
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
