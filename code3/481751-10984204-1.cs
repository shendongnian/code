    public static string RtfToHtml(string rtfText)
    {
        if (String.IsNullOrEmpty(rtfText)) return rtfText;
        if (!rtfText.Contains(@"{\rtf1")) return rtfText.Replace("\r\n", "<br>").Replace("\r", "<br>");
    
        Converter converter = new Converter();
        StringBuilder sb = new StringBuilder(converter.ConvertRtfToHtml(rtfText));
    	string html = Regex.Replace(sb.ToString(), @"font-size:(\d*(\.\d+)?);", @"font-size:$1pt;");
        try
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            RemoveStyleTags(doc, "ol");
            RemoveStyleTags(doc, "ul");
            RemoveStyleTags(doc, "li");
            return doc.DocumentNode.InnerHtml;
        }
        catch { }
    
        return html;
    }
