    using System.Text.RegularExpressions;
    ...
    public static readonly REGEX_QUOTEFINDER = @"{0}\s*""(?<QUOTE>([^""]+))""";
    public static string ReadQuotedString(string blob, string key)
    {
        return Regex.Match(
            blob, 
            string.Format(REGEX_QUOTE, Regex.Escape(key))
        ).Group["QUOTE"].Value;
    }
    ...
    string result = ReadQuotedString(File.ReadAllText("c:/test.txt"), "Description");
