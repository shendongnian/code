    static readonly long DATE1970_TICKS = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks;
    static readonly Regex DATE_SERIALIZATION_REGEX = new Regex(@"\\/Date\((?<ticks>-?\d+)\)\\/", RegexOptions.Compiled);
    
    static string ISO8601Serialization(string input)
    {
        return DATE_SERIALIZATION_REGEX.Replace(input, match =>
        {
            var ticks = long.Parse(match.Groups["ticks"].Value) * 10000;
            return new DateTime(ticks + DATE1970_TICKS).ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fff");
        });
    }
