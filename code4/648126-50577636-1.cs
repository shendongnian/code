    private static readonly Encoding Encoding1252 = Encoding.GetEncoding(1252);
    public static byte[] SHA1HashValue(string s)
    {
        byte[] bytes = Encoding1252.GetBytes(s);
        var sha1 = SHA512.Create();
        byte[] hashBytes = sha1.ComputeHash(bytes);
        return hashBytes;
    }
