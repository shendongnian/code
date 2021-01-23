    public static byte[] ToByteArray(this string source)
    {
        return
            Regex.Matches(source.PadLeft(source.Length + source.Length % 8, '0'), "[01]{0,8}")
            .Cast<Match>()
            .Where(m => m.Success && !String.IsNullOrWhiteSpace(m.Groups[0].Value))
            .Select(m => Convert.ToByte(m.Groups[0].Value, 2))
            .ToArray();
    }
