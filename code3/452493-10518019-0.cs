    static long DATE1970_TICKS = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).Ticks;
    static Regex DATE_SERIALIZATION_REGEX = new Regex(@"\\/Date\((?<ticks>-?\d+)\)\\/", RegexOptions.Compiled);
    
    private static string ISO8601Serialization(string input)
    {
        Match match;
    
        while ((match = DATE_SERIALIZATION_REGEX.Match(input)).Success)
        {
            long ticks = long.Parse(match.Groups["ticks"].Value) * 10000;
            DateTime dateTime = new DateTime(ticks + DATE1970_TICKS).ToLocalTime();
            input = input.Replace(match.Value, dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
        }
    
        return input;
    }
