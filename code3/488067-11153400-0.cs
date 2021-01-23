    public class ErrorValue
    {
        private static Dictionary<Int32, ErrorValue> _errors;
        public static readonly ErrorValue Error404 = new ErrorValue(404, "Error 404");
        public static readonly ErrorValue Error500 = new ErrorValue(500, "Error 500");
        public static readonly ErrorValue Error301 = new ErrorValue(301, "Error 301");
        public String ErrorName { get; private set; }
        public Int32 ErrorCode { get; private set; }
        private ErrorValue(Int32 errorCode, String errorName)
        {
            if (_errors == null)
                _errors = new Dictionary<int, ErrorValue>();
            ErrorName = errorName;
            ErrorCode = errorCode;
            _errors.Add(errorCode, this);
        }
        public static IEnumerable<ErrorValue> Errors { get { return _errors.Values; } }
        public static ErrorValue GetErrorByCode(Int32 errorCode)
        {
            return _errors[errorCode];
        }
    }
