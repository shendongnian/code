    public static string HmacSha256Digest(this string message, string secret)
    {
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] keyBytes = encoding.GetBytes(secret);
        byte[] messageBytes = encoding.GetBytes(message);
        System.Security.Cryptography.HMACSHA256 cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);
    
        byte[] bytes = cryptographer.ComputeHash(messageBytes);
    
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
