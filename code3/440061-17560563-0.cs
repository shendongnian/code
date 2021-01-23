    using System.Security;
    /// <summary>
    /// Returns a Secure string from the source string
    /// </summary>
    /// <param name="Source"></param>
    /// <returns></returns>
    public static SecureString ToSecureString(this string Source)
    {
        if (string.IsNullOrWhiteSpace(Source))
            return null;
        else
        {
            SecureString Result = new SecureString();
            foreach (char c in Source.ToCharArray())
                Result.AppendChar(c);
            return Result;
        }
    }
