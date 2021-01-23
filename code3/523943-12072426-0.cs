    public class CustomException : Exception
    {
        private readonly string _customField;
        public CustomException(string customField, string message)
            : base(message)
        {
            Init(out _customField, customField);
        }
        public CustomException(string customField)
            : base()
        {
            Init(out _customField, customField);
        }
        private Init(out string _customField, string customField)
        {
            _customField = customField;
        }
    }
