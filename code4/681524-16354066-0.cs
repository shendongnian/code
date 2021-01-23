    public class CustomValidationErrorException : Exception
    {
        public string Id { get; set; } // Custom Id for the operation
        public IEnumerable<string> Messages { get; set; } // Multiple validation error message
    }
