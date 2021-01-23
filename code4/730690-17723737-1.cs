    public class ParameterisedRequiredAttribute : RequiredAttribute
        {
            private string[] _replacements { get; set; }
    
            public ParameterisedRequiredAttribute(params string[] replacements)
            {
                _replacements = replacements;
    
                ErrorMessageResourceName = ErrorMessagesErrors.SpecificFieldRequired;
                ErrorMessageResourceType = typeof(ErrorMessages);
            }
    
            public override string FormatErrorMessage(string name)
            {
                return string.Format(ErrorMessageString, (object[])_replacements);
            }
        }
