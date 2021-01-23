    private static string UnicodeSubstring(string text, int length)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var result = Encoding.UTF8.GetString(bytes, 0, Math.Min(bytes.Length, length));
            
        while ('\uFFFD' == result[result.Length - 1])
        {
            result = result.Substring(0, result.Length - 1);
        }
        return result;
    }
