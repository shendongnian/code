    public class PasswordException : Exception
    {
        public PasswordException(PasswordResult result) : base() { }
        public PasswordException(PasswordResult result, string message) : base(message) { }
        public PasswordException(PasswordResult result, string message, Exception innerException) : base(message, innerException) { }
    }
    public enum PasswordResult
    {
        Success = 0,
        PasswordMismatch,
        PasswordEmpty,
        // and so forth
    }
