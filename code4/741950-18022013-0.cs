    public static string EncryptText(string input)
    {
        byte[] unencryptedBytes = Encoding.UTF8.GetBytes(input);
        byte[] encryptedBytes = EncryptBytes(unencryptedBytes); // Not shown here
        return Convert.ToBase64String(encryptedBytes);
    }
    public static string DecryptText(string input)
    {
        byte[] encryptedBytes = Convert.FromBase64String(input);
        byte[] unencryptedBytes = DecryptBytes(encryptedBytes); // Not shown here
        return Encoding.UTF8.GetString(unencryptedBytes);
    }
