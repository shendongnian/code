    public class ModelClientValidationCompareStringsRule : ModelClientValidationRule
    {
        public ModelClientValidationCompareStringsRule(string errorMessage, string otherProperty, bool ignoreCase)
        {
            ErrorMessage = errorMessage;  //The error message to display when invalid. Note we used FormatErrorMessage above to ensure this matches the server-side result.
            ValidationType = "comparestrings";    //Choose a unique name for your validator on the client side. This doesn't map to anything on the server side.
            ValidationParameters.Add("otherprop", otherProperty);  //Pass the name of the property to compare to
            ValidationParameters.Add("ignorecase", ignoreCase.ToString().ToLower());  //And whether to ignore casing
        }
    }
