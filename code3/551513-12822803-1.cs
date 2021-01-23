    using (WebClient wc = new WebClient())
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(wc.DownloadString("http://www.google.com"));
        doc.OptionOutputAsXml = true;
        StringWriter writer = new StringWriter();
        doc.Save(writer);
        var xDoc = XDocument.Load(new StringReader(writer.ToString()));
    }
