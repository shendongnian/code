    using(WebClient client = new WebClient())
    {
        client.Encoding = System.Text.Encoding.UTF8;
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(client.DownloadString("http://www.google.com?q=stackoverflow"));
        foreach (var href in doc.DocumentNode.Descendants("a").Select(x => x.Attributes["href"]))
        {
            if (href == null) continue;
            href.Value = "http://ahmadalli.somee.com/default.aspx?url=" + HttpUtility.UrlEncode(href.Value);
        }
        StringWriter writer = new StringWriter();
        doc.Save(writer);
        var finalHtml = writer.ToString();
    }
