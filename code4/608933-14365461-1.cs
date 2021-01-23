    using System.Runtime.InteropServices; // For Marshal static class
    using System.Security;                // For SecureString class
    public static class SecureStringExtender
    {
      public static SecureString ConvertToSecureString(this string text)
      {
        if (text == null)
          throw new ArgumentNullException("text");
        var secureString = new SecureString();
        foreach(var c in text)
          secureString.AppendChar(c);
        secureString.MakeReadOnly();
        return secureString;
      }
      public static string ConvertToInsecureString(this SecureString secureString)
      {
        if (secureString == null)
          throw new ArgumentNullException("secureString");
        IntPtr unmanagedString = IntPtr.Zero;
        try
        {
          unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
          return Marshal.PtrToStringUni(unmanagedString);
        }
        finally
        {
          // Zero out the sensitive text in memory for security purposes.
          Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
      }
    }
