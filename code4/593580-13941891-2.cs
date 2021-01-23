    public class MyEmailValidationAttribute : RegularExpressionAttribute
    {
        public MyEmailValidationAttribute ()
            : base(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$")
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex RegexObj = new Regex(this.Pattern);
            
            if (value == null)
            {
                return ValidationResult.Success;
            }           
            Match match = RegexObj.Match((string)value);
            if (!match.Success)
            {
                return new ValidationResult("Email not in correct format.");
            }
            return ValidationResult.Success;     
        }
    }
