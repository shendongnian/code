    using System.Security;
    .
    .
    .
    /// <summary>
    /// Converts String to SecureString
    /// </summary>
    /// <param name="input">Input in String</param>
    /// <returns>Input in SecureString</returns>
    public SecureString String2SecureString(String input) {
        SecureString _output = new SecureString();
        input.ToCharArray().ToList().ForEach((q) => _output.AppendChar(q));
        return _output;
    }
