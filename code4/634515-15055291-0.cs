    static void Main(string[] args)
    {
        var encoded = Base64Encode("test string");
        var decoded = Base64Decode(encoded);
    }
    static string Base64Encode(string text)
    {
        var bytes = System.Text.UTF8Encoding.UTF8.GetBytes(text);
        return System.Convert.ToBase64String(bytes);            
    }
    static string Base64Decode(string encodedText)
    {
        var bytes = System.Convert.FromBase64String(encodedText);
        return System.Text.UTF8Encoding.UTF8.GetString(bytes);            
    }
