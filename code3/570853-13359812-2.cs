    public class StringLenghtWarningValidationRule : ModelClientValidationRule
    {
        public StringLenghtWarningValidationRule(int maximumLength, string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "stringlengthwarning";
            ValidationParameters.Add("maximumlength", maximumLength);
            ValidationParameters.Add("ignorewarningsfield", "IgnoreWarnings");
        }
    }
