    public static byte[] ToByteArray(this string source)
    {
        return
            Regex.Matches(new String(source.Reverse().ToArray()), "[01]{0,8}")
            .Cast<Match>()
            .Select(m => m.Groups[0].Value)
            .Where(s => !String.IsNullOrWhiteSpace(s))
            .Select(s => s.Select((c, i) => (c == '0') ? 0 : Math.Pow(2, i)).Sum())
            .Select(Convert.ToByte)
            .Reverse()
            .ToArray();
    }
