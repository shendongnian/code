    /// <summary>
    /// Extracts selected Html fragment string from clipboard data by parsing header information 
    /// in htmlDataString
    /// </summary>
    /// <param name="htmlDataString">
    /// String representing Html clipboard data. This includes Html header
    /// </param>
    /// <returns>
    /// String containing only the Html selection part of htmlDataString, without header
    /// </returns>
    internal static string ExtractHtmlFragmentFromClipboardData(string htmlDataString)
    {
        // HTML Clipboard Format
        // (https://msdn.microsoft.com/en-us/library/aa767917(v=vs.85).aspx)
        // The fragment contains valid HTML representing the area the user has selected. This 
        // includes the information required for basic pasting of an HTML fragment, as follows:
        //  - Selected text. 
        //  - Opening tags and attributes of any element that has an end tag within the selected text. 
        //  - End tags that match the included opening tags. 
        // The fragment should be preceded and followed by the HTML comments <!--StartFragment--> and 
        // <!--EndFragment--> (no space allowed between the !-- and the text) to indicate where the 
        // fragment starts and ends. So the start and end of the fragment are indicated by these 
        // comments as well as by the StartFragment and EndFragment byte counts. Though redundant, 
        // this makes it easier to find the start of the fragment (from the byte count) and mark the 
        // position of the fragment directly in the HTML tree.
        // Byte count from the beginning of the clipboard to the start of the fragment.
        int startFragmentIndex = htmlDataString.IndexOf("StartFragment:");
        if (startFragmentIndex < 0)
        {
            return "ERROR: Unrecognized html header";
        }
        // TODO: We assume that indices represented by strictly 10 zeros ("0123456789".Length),
        // which could be wrong assumption. We need to implement more flrxible parsing here
        startFragmentIndex = Int32.Parse(htmlDataString.Substring(startFragmentIndex + "StartFragment:".Length, 10));
        if (startFragmentIndex < 0 || startFragmentIndex > htmlDataString.Length)
        {
            return "ERROR: Unrecognized html header";
        }
        // Byte count from the beginning of the clipboard to the end of the fragment.
        int endFragmentIndex = htmlDataString.IndexOf("EndFragment:");
        if (endFragmentIndex < 0)
        {
            return "ERROR: Unrecognized html header";
        }
        // TODO: We assume that indices represented by strictly 10 zeros ("0123456789".Length),
        // which could be wrong assumption. We need to implement more flrxible parsing here
        endFragmentIndex = Int32.Parse(htmlDataString.Substring(endFragmentIndex + "EndFragment:".Length, 10));
        if (endFragmentIndex > htmlDataString.Length)
        {
            endFragmentIndex = htmlDataString.Length;
        }
        // CF_HTML is entirely text format and uses the transformation format UTF-8
        byte[] bytes = Encoding.UTF8.GetBytes(htmlDataString);
        return Encoding.UTF8.GetString(bytes, startFragmentIndex, endFragmentIndex - startFragmentIndex);
    }
