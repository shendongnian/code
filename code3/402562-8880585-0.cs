    public class LoginException : Exception
    {
        public LoginException(LoginResult result) : base() { }
        public LoginException(LoginResult result, string message) : base(message) { }
        public LoginException(LoginResult result, string message, Exception innerException) : base(message, innerException) { }
    }
    public enum LoginResult
    {
        Success = 0,
        PasswordMismatch,
        PasswordEmpty,
        // and so forth
    }
