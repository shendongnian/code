    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    ...
    public class RequiredExAttribute : RequiredAttribute
    {
        public bool IsRequired { get; set; }
        public override bool IsValid(object value)
        {
            if (IsRequired)
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
                return IsRequired;
            }
        }
    }
    public class RequiredExAttributeAdapter : RequiredAttributeAdapter
    {
        public RequiredExAttributeAdapter(ModelMetadata metadata, ControllerContext context, RequiredExAttribute attribute)
            : base(metadata, context, attribute) { }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (((RequiredExAttribute)Attribute).IsRequired)// required -> return normal required rules
                return base.GetClientValidationRules();
            else// not required -> return empty rules list
                return new List<ModelClientValidationRule>();
        }
    }
