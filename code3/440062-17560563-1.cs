    using System.Security;
    /// <summary>
    /// Returns a Secure string from the source string
    /// </summary>
    /// <param name="Source"></param>
    /// <returns></returns>
    public static SecureString ToSecureString(this string source)
    {
        if (string.IsNullOrWhiteSpace(source))
            return null;
        else
        {
            SecureString result = new SecureString();
            foreach (char c in source.ToCharArray())
                result.AppendChar(c);
            return result;
        }
    }
