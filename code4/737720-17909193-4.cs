    using System.Security;
    // ...
    public static SecureString ConvertToSecureString(this string password)
    {
        if (password == null)
            throw new ArgumentNullException("password");
    
        unsafe
        {
            fixed (char* passwordChars = password)
            {
                var securePassword = new SecureString(passwordChars, password.Length);
                securePassword.MakeReadOnly();
                return securePassword;
            }
        }
    }
