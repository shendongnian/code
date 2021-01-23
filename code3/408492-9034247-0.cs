    public static string Crypt (this string text)
    {
        return Convert.ToBase64String (
            ProtectedData.Protect (
                Encoding.Unicode.GetBytes (text) ) );
    }
    public static string Derypt (this string text)
    {
        return Encoding.Unicode.GetString (
            ProtectedData.Unprotect (
                 Convert.FromBase64String (text) ) );
    }
