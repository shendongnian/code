    public static string QueryStringHash(string input)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes();
        SHA512Managed sha512 = new SHA512Managed();
        byte[] outputBytes = sha512.ComputeHash(inputBytes);
        string b64 = Convert.ToBase64String(outputBytes);
        b64 = b64.Replace('+', '-');
        return b64.Replace('/', '_');
    }
