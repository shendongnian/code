    private static Random Random = new Random();
    public static string GenerateRandomString(int length, string characterSet = "abcdefghijklmnopqrstuvwxyzABCDDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        var builder = new StringBuilder();
        while(builder.Length < length) 
        {
            builder.Append(characterSet.Chars[Random.Next(characterSet.Length)]);
        }
        return builder.ToString();
    }
