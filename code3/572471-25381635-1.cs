    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class CCompareAttribute : ValidationAttribute, IClientValidatable
        {
            private const string _defaultErrorMessage = "Confirm password should match with password field.";
            private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;
            private string name;
            public CCompareAttribute(string compare)
                : base(_defaultErrorMessage)
            {
                name = compare;
            }
            public override string FormatErrorMessage(string name)
            {
                return String.Format(CultureInfo.CurrentCulture, ErrorMessageString);
            }
            public override bool IsValid(object value)
            {
                string valueAsString = value as string;
                return (valueAsString != null);
            }
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                return new[]{
                new ModelClientValidationEqualToRule(FormatErrorMessage(metadata.GetDisplayName()),name)
            };
            }
        }
        [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
        public class TypeErrorMessageAttribute : Attribute
        {
            public string ErrorMessage { get; set; }
            public string ErrorMessageResourceName { get; set; }
            public Type ErrorMessageResourceType { get; set; }
            public TypeErrorMessageAttribute()
            {
            }
            public string GetErrorMessage()
            {
                PropertyInfo prop = ErrorMessageResourceType.GetProperty(ErrorMessageResourceName);
                return prop.GetValue(null, null).ToString();
            }
        }
