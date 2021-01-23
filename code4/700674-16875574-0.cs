    public static string StripHtmlTags(string html)
    {
    	if (String.IsNullOrEmpty(html)) return "";
    	HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    	doc.LoadHtml(html);
    	return HttpUtility.HtmlDecode(doc.DocumentNode.InnerText);
    }
