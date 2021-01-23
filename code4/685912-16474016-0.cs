    using System.Text.RegularExpressions;
    string sURL = "http://subdomain.website.com/index.htm";
    string sPattern = @"\w+.com";
    // Instantiate the regular expression object.
    Regex r = new Regex(sPattern, RegexOptions.IgnoreCase);
    // Match the regular expression pattern against a text string.
    Match m = r.Match(sUrl);
    if (m.Success)
    {
        MessageBox.Show(m.Value);
    }
