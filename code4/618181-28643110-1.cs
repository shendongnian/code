    /// <summary>
    /// Extracts Html string from clipboard data by parsing header information in htmlDataString
    /// </summary>
    /// <param name="htmlDataString">
    /// String representing Html clipboard data. This includes Html header
    /// </param>
    /// <returns>
    /// String containing only the Html data part of htmlDataString, without header
    /// </returns>
    internal static string ExtractHtmlFromClipboardData(string htmlDataString)
    {
        int startHtmlIndex = htmlDataString.IndexOf("StartHTML:");
        if (startHtmlIndex < 0)
        {
            return "ERROR: Urecognized html header";
        }
        // TODO: We assume that indices represented by strictly 10 zeros ("0123456789".Length),
        // which could be wrong assumption. We need to implement more flrxible parsing here
        startHtmlIndex = Int32.Parse(htmlDataString.Substring(startHtmlIndex + "StartHTML:".Length, "0123456789".Length));
        if (startHtmlIndex < 0 || startHtmlIndex > htmlDataString.Length)
        {
            return "ERROR: Urecognized html header";
        }
        int endHtmlIndex = htmlDataString.IndexOf("EndHTML:");
        if (endHtmlIndex < 0)
        {
            return "ERROR: Urecognized html header";
        }
        // TODO: We assume that indices represented by strictly 10 zeros ("0123456789".Length),
        // which could be wrong assumption. We need to implement more flrxible parsing here
        endHtmlIndex = Int32.Parse(htmlDataString.Substring(endHtmlIndex + "EndHTML:".Length, "0123456789".Length));
        if (endHtmlIndex > htmlDataString.Length)
        {
            endHtmlIndex = htmlDataString.Length;
        }
        return htmlDataString.Substring(startHtmlIndex, endHtmlIndex - startHtmlIndex);
    }
