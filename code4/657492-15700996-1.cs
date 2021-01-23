    private delegate string ConvertFunc(string input);
    private string ModifyString(string input, ConvertFunc conversion)
    {
        MatchCollection matches = Regex.Matches(input, "\".*?\"");
        int lastPos = 0;
        StringBuilder stringBuilder = new StringBuilder(input.Length);
        foreach (Match match in matches)
        {
            int currentPos = match.Index;
            string toConvert = input.Substring(lastPos, currentPos - lastPos);
            string converted = conversion(toConvert);
            stringBuilder.Append(converted);
            stringBuilder.Append(match.Value);
            lastPos = currentPos + match.Length;
        }
        if (lastPos < input.Length)
        {
            stringBuilder.Append(conversion(input.Substring(lastPos)));
        }
        return stringBuilder.ToString();
    }
    private string ToUpper(string toConvert)
    {
        return toConvert.ToLower();
    }
