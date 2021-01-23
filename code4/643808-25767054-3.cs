    public static string SplitToLines(string originalText, char[] splitOnCharacters, int maxStringLength)
    {
        var sb = new StringBuilder();
        var index = 0;
        while (originalText.Length > index)
        {
            // get the next substring, else the rest of the string if remainder is shorter than `maxStringLength`
            var splitAt = index + maxStringLength <= originalText.Length ?
                originalText.Substring(index, maxStringLength).LastIndexOfAny(splitOnCharacters) :
                originalText.Length - index;
            // if can't find split location, take `maxStringLength` characters
            splitAt = (splitAt == -1) ? maxStringLength : splitAt;
            // add result to collection & increment index
            sb.AppendLine(originalText.Substring(index, splitAt).Trim());
            index += splitAt;
        }
        return sb.ToString();
    }
