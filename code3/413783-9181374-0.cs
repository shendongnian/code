    public class ValidationResult
    {
        public ValidationResult(bool passed, string message)
        {
            this.Passed = passed;
            this.ErrorMessage = message ?? string.Empty;
        }
        public ValidationResult Add(ValidationResult other)
        {
            this.Passed &&= other.Passed;
            this.Message += "\n" + other.Message;
            return this;
        } 
        public string ErrorMessage {get; private set; }
        public bool Passed { get; private set; }
    }
