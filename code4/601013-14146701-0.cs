    public static string HashString(string cleartext)
    {
        byte[] clearBytes = Encoding.UTF8.GetBytes(cleartext);
        return HashBytes(clearBytes);
    }  
    public static string HashBytes(byte[] clearBytes)
    {
        SHA1 hasher = SHA1.Create();
        byte[] hashBytes =   hasher.ComputeHash(clearBytes);
        string hash = System.Convert.ToBase64String(hashBytes);
        hasher.Clear();
        return hash;
    }
