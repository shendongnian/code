    private static readonly Dictionary<string, string> Map
        = new Dictionary<string, string> {
        {"11", "c"},
        {"12", "o"},
        {"13", "m"}
    };
    public static string Rewrite(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i += 2)
        {
            string value = input.Substring(i, 2);
            sb.Append(Map[value]);
        }
        return sb.ToString();
    }
