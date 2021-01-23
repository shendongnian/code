    public class ValidationRule
    {
        public ValidationRule(Func<bool> test, string errorMessage)
        {
            this.Test = test;
            this.ErrorMessage = errorMessage;
        }
        public Func<bool> Test { get; private set; }
        public string ErrorMessage { get; private set; }
    }
    var validationRules = new[] {
        new ValidationRule(() => input != string.Empty, "Nothing to encrypt!"),
        new ValidationRule(() => typeComboBox.Text != null, "Nothing Selected!")
    };
