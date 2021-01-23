    class IsNullOrEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string s = (value ?? string.Empty).ToString();
            if (string.IsNullOrEmpty(s))
            {
                // Invalid...
                return new ValidationResult(false, "Please enter a value.");
            }
            else
            {
                // Valid...
               return new ValidationResult(true, null);
            }
        }
    }
