    /// <summary>
    /// Returns only the first n characters of a String.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="start"></param>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public static string TruncateString(this string str, int start, int maxLength)
    {        
        return str.Substring(start, Math.Min(str.Length, maxLength));
    }
