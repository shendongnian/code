    public static string GetMD5(string text)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] hash = MD5.Create().ComputeHash(textBytes);
     
        return Convert.ToBase64String(hash);
    }
