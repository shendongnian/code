    /// <summary>
    /// Replace a string char at index with another char
    /// </summary>
    /// <param name="text">string to be replaced</param>
    /// <param name="index">position of the char to be replaced</param>
    /// <param name="c">replacement char</param>
    public static string ReplaceAtIndex(this string text, int index, char c)
    {
        var stringBuilder = new StringBuilder(text);
        stringBuilder[index] = c;
        return stringBuilder.ToString();
    }
