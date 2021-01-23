    public static string TrimLength(string text, int maxLength)
    {
        if (text.Length > maxLength)
        {
            maxLength -= "...".Length;
            maxLength = text.Length < maxLength ? text.Length : maxLength;
            bool isLastSpace = text[maxLength] == ' ';
            string part = text.Substring(0, maxLength);
            if (isLastSpace)
                return part + "...";
            if (lastSpaceIndexBeforeMax == -1)
                return part + "...";
            else
                return text.Substring(0, lastSpaceIndexBeforeMax) + "...";
        }
        else
            return text;
    }
