    private string EncodeHMAC(string input, byte[] key)
    {
        HMACSHA1 hmac = new HMACSHA1(key);
        byte[] stringBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedValue = hmac.ComputeHash(stringBytes);
        return Convert.ToBase64String(hashedValue);
    }
