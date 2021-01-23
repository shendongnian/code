    public static string TrimLength(string text, int maxLength)
    {
        if (text.Length > maxLength)
        {
            maxLength -= "...".Length;
            string part = text.Substring(0, maxLength);
            int lastSpaceIndexBeforeMax = part.LastIndexOf(' ');
            return text.Substring(0, lastSpaceIndexBeforeMax) + "...";
        }
        else
            return text;
    }
