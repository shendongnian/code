    public class FieldError
    {
        public String FieldName { get; set; }
        public String FieldMessage { get; set; }
    }
    // a result will be able to inform API client about some general error/information and details information (related to invalid parameter values etc.)
    public class ValidationResult<T>
    {
        public bool IsError { get; set; }
        /// <summary>
        /// validation message. It is used as a success message if IsError is false, otherwise it is an error message
        /// </summary>
        public string Message { get; set; } = string.Empty;
        public List<FieldError> FieldErrors { get; set; } = new List<FieldError>();
        public T Payload { get; set; }
        public void AddFieldError(string fieldName, string fieldMessage)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("Empty field name");
            if (string.IsNullOrWhiteSpace(fieldMessage))
                throw new ArgumentException("Empty field message");
            // appending error to existing one, if field already contains a message
            var existingFieldError = FieldErrors.FirstOrDefault(e => e.FieldName.Equals(fieldName));
            if (existingFieldError == null)
                FieldErrors.Add(new FieldError {FieldName = fieldName, FieldMessage = fieldMessage});
            else
                existingFieldError.FieldMessage = $"{existingFieldError.FieldMessage}. {fieldMessage}";
            IsError = true;
        }
        public void AddEmptyFieldError(string fieldName, string contextInfo = null)
        {
            AddFieldError(fieldName, $"No value provided for field. Context info: {contextInfo}");
        }
    }
    public class ValidationResult : ValidationResult<object>
    {
        
    }
