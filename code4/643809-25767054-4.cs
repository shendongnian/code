    public static string SplitToLines(string text, char[] splitOnCharacters, int maxStringLength)
    {
        var sb = new StringBuilder();
        var index = 0;
        while (text.Length > index)
        {
            // start a new line, unless we've just started
            if (index != 0)
                sb.AppendLine();
            // get the next substring, else the rest of the string if remainder is shorter than `maxStringLength`
            var splitAt = index + maxStringLength <= text.Length
                ? text.Substring(index, maxStringLength).LastIndexOfAny(splitOnCharacters)
                : text.Length - index;
            // if can't find split location, take `maxStringLength` characters
            splitAt = (splitAt == -1) ? maxStringLength : splitAt;
            // add result to collection & increment index
            sb.Append(text.Substring(index, splitAt).Trim());
            index += splitAt;
        }
        return sb.ToString();
    }
