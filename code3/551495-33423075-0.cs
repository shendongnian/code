    //Create your custom validation attribute
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class CompareStrings : ValidationAttribute, IClientValidatable
    {
        private const string _defaultErrorMessage = "{0} must match {1}";
        public string OtherPropertyName { get; set; }
        public bool IgnoreCase { get; set; }
        public CompareStrings(string otherPropertyName)
            : base(_defaultErrorMessage)
        {
            if (String.IsNullOrWhiteSpace(otherPropertyName)) throw new ArgumentNullException("OtherPropertyName must be set.");
            OtherPropertyName = otherPropertyName;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessage, name, OtherPropertyName);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string otherPropVal = validationContext.ObjectInstance.GetType().GetProperty(OtherPropertyName).GetValue(validationContext.ObjectInstance, null) as string;
            //Convert nulls to empty strings and trim spaces off the result
            string valString = (value as string ?? String.Empty).Trim();
            string otherPropValString = (otherPropVal ?? String.Empty).Trim();
            bool isMatch = String.Compare(valString, otherPropValString, IgnoreCase) == 0;
            if (isMatch)
                return ValidationResult.Success;
            else
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
