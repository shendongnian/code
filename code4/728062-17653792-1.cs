    /// <summary>
    /// Returns the DataFormat string of the text.
    /// </summary>
    /// <param name="text">Text to check.</param>
    /// <returns>Value from the <see cref="DataFormats"/> enumeration.</returns>
    public static string GetDataFormat(this string text)
    {
        // First validate the text
        if (string.IsNullOrEmpty(text)) return System.Windows.DataFormats.Text;
    
        // Return right data
        if (text.StartsWith(@"{\rtf")) return System.Windows.DataFormats.Rtf;
        // Return default
        return System.Windows.DataFormats.Text;
    }
