    public class StringLengthWarningValidationRule : ModelClientValidationRule
    {
        public StringLengthWarningValidationRule(int maximumLength, string errorMessage)
        {
            ErrorMessage = errorMessage;
            ValidationType = "stringlengthwarning";
            ValidationParameters.Add("maximumlength", maximumLength);
            ValidationParameters.Add("ignorewarningsfield", "IgnoreWarnings");
        }
    }
