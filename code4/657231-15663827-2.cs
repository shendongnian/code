    // TODO: Improve the name :)
    public static string TruncateAfterSeparatorCount(string text,
                                                     string separator,
                                                     int count)
    {
        // We pretend that the string "starts" with a separator before index 0.
        int index = -separator.Length;
        for (int i = 0; i < count; i++)
        {
            int nextIndex = text.IndexOf(separator, index + separator.Length);
            // Not enough separators. Return the whole string. Could throw instead.
            if (nextIndex == -1)
            {
                return text;
            }
            index = nextIndex;
        }
        // We need to handle the count == 0 case, where index will be negative...
        return text.Substring(0, Math.Max(index, 0));
    }
