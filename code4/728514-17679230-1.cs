    private struct ErrorInfo
    {
        public readonly string Value;
        public readonly string Message;
        public ErrorInfo(string value, string message)
        {
            Value = value;
            Message = message;
        }
    }
    private readonly Dictionary<string, ErrorInfo> errorList = new Dictionary<string, ErrorInfo>();
    public string this[string propertyName]
    {
        get
        {
            ErrorInfo error;
            if (errorList.TryGetValue(propertyName, out error))
                return error.Message;
            return String.Empty;
        }
    }
    public string Error { get { return String.Empty; } }
