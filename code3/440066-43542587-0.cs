    public static SecureString ToSecureString(this string source)
    {
        char[] charArray = source.ToCharArray();
        unsafe
        {
            fixed (char* chars = charArray)
            {
                return new SecureString(chars, charArray.Length);
            }
        }
    }
