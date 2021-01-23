    [AttributeUsage(AttributeTargets.Property)]
        public sealed class AtLeastOneOrTwoParamsHasValue : ValidationAttribute, IClientValidatable
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var param1 = validationContext.ObjectInstance.GetType().GetProperty("Param1").GetValue(value, null);
                //var param2 = validationContext.ObjectInstance.GetType().GetProperty("Param2").GetValue(value, null);
    
                //DO Compare logic here.
    
                if (!string.IsNullOrEmpty(Convert.ToString(param1)))
                {
                    return ValidationResult.Success;
                }
               
    
                return new ValidationResult("Some Error");
            }
    
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                //Do custom client side validation hook up
    
                yield return new ModelClientValidationRule
                {
                    ErrorMessage = FormatErrorMessage(metadata.DisplayName),
                    ValidationType = "validParam"
                };
            }
        }
