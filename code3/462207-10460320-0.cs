    private static string MessedUpUrlDecode(string input, string encoding)
    {
        Encoding enc = new ASCIIEncoding();
        try
        {
            enc = Encoding.GetEncoding(charSet);
        }
        catch
        {
            enc = new UTF8Encoding();
        }
        string messedup = input.Split('?')[3];
        string cleaned = input.Replace("_", " ").Replace("=...", ".").Replace("=", "%");
        return System.Web.HttpUtility.UrlDecode(cleaned, enc);
    }
