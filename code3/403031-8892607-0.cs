    private static string GetMD5Hash(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        using (var md5 = MD5.Create())
        {
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
