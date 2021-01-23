    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter , AllowMultiple = false, Inherited = true)]
    public sealed class MinRequiredPasswordLengthAttribute : ValidationAttribute, IClientValidatable
    {                        
        private readonly int _minimumLength = Membership.MinRequiredPasswordLength;        
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _minimumLength);
        } 
        public override bool IsValid(object value)
        {           
            string password = value.ToString();
            return password.Length >= this._minimumLength;            
        }        
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[]{
                new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), _minimumLength, int.MaxValue)
            };
        } 
    }
