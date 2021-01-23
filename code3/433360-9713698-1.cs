    static void Main(string[] args)
    {
        var obj = new Dictionary<string, string>()
            {
                { "foo", "bar" },
                { "baz", "ack" },
            };
        var stringVersion = GetStringVersion(obj);
        Console.WriteLine(stringVersion);
    }
    private static string GetStringVersion<TKey, TValue>(Dictionary<TKey, TValue> dict)
    {
        return "{" + string.Join(Environment.NewLine, dict.Select(e => string.Format("  {0}: {1}", e.Key, e.Value))) + "}";
    }
