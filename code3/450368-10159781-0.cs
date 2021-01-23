    public class Login
    {
        public bool AccountExists(string name) {
            bool exists;
            // do checking
            return exists;
        }
        public LoginResult Login(string name, string password) {
            // Try login
            // If successful
            return LoginResult.Success;
            // What if the user does not exist?
            return LoginResult.AccountNotFound;
            // What about an error?
            return LoginResult.Error;
        }
    }
    public enum LoginResult
    {
        None,
        AccountNotFound,
        Error,
        Success
    }
