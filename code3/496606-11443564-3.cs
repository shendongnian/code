    class ValidationException : ApplicationException
    {
        public JsonResult exceptionDetails;
        public ValidationException(JsonResult exceptionDetails)
        {
            this.exceptionDetails = exceptionDetails;
        }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inner) : base(message, inner) { }
        protected ValidationException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
