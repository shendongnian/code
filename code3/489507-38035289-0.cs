    public static int CountLines(this string text)
    {
        int count = 0;
        if (!string.IsNullOrEmpty(text))
        {
            count = text.Length - text.Replace("\n", string.Empty).Length;
            // if the last char of the string is not a newline, make sure to count that line too
            if (text[text.Length - 1] != '\n')
            {
                ++count;
            }
        }
        return count;
    }
