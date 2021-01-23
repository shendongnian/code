    private static SHA1CryptoServiceProvider SHA = new SHA1CryptoServiceProvider();
    private static string CalculateSHA1(string text, Encoding enc)
    {
        byte[] buffer = enc.GetBytes(text);
        return BitConverter.ToString(SHA.ComputeHash(buffer)).Replace("-", "");
    }
