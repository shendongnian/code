    private static int saltLengthLimit = 32;
    private static byte[] GetSalt(int maximumSaltLength)
    {
        var salt = new byte[maximumSaltLength];
        using (var random = new RNGCryptoServiceProvider())
        {
            random.GetNonZeroBytes(salt);
        }
    
        return salt;
    }
    public static byte[] CreateKey(string password)
    {
        var salt = GetSalt(10);
        int iterationCount = 20000; // Nowadays you should use at least 10.000 iterations
        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterationCount))
            return rfc2898DeriveBytes.GetBytes(16);
    }
