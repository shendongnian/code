    public static bool HasContent(this string text)
    {
        if (text == null)
        {
            return false;
        }
        foreach (char c in text)
        {
            if (!char.IsWhitespace(c))
            {
                return true;
            }
        }
        return false;
    }
