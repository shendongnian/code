     public class RequiredExAttribute : RequiredAttribute
        {
            public bool UseRequiredAttribute { get; protected set; }
            public RequiredExAttribute(bool IsRequired)
            {
                UseRequiredAttribute = IsRequired;
            }
            public override bool IsValid(object value)
            {
                if (UseRequiredAttribute)
                    return base.IsValid(value);
                else
                {
                    return true;
                }
            }
    
            public override bool RequiresValidationContext
            {
                get
                {
                    return UseRequiredAttribute;
                }
            }
        }
    
        public class RequiredExAttributeAdapter : RequiredAttributeAdapter
        {
            public RequiredExAttributeAdapter(ModelMetadata metadata, ControllerContext context, RequiredExAttribute attribute)
                : base(metadata, context, attribute) { }
            
            public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
            {
                if (((RequiredExAttribute)Attribute).UseRequiredAttribute)// required -> return normal required rules
                    return base.GetClientValidationRules();
                else// not required -> return empty rules list
                    return new List<ModelClientValidationRule>();
            }
        }
