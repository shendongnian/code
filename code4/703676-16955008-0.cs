    /// <summary>This removes the first occurrence  of the specified target string in the given text.</summary>
    /// <param name="text">The text from which to remove the target string.</param>
    /// <param name="target">The target string to remove.</param>
    /// <param name="delimiter">The delimiter string used between potential target strings.</param>
    /// <returns>The text with first occurrence  (if any) of the target string removed.</returns>
    public static string RemoveFirstMatch(string text, string target, string delimiter)
    {
        if (text == null)
            throw new ArgumentNullException("text");
        if (target == null)
            throw new ArgumentNullException("target");
        if (text.StartsWith(target + delimiter))
            return text.Substring(target.Length + delimiter.Length);
        if (text.EndsWith(delimiter + target))
            return text.Substring(0, text.Length - target.Length - delimiter.Length);
        return text.Replace(delimiter + target + delimiter, delimiter);
    }
