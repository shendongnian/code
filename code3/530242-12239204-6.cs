    //** replace this with any url **
    string url = "http://www.bbc.co.uk/news/world-asia-19457334";
    var t = new NReadability.NReadabilityWebTranscoder();
    bool b;
    string page = t.Transcode(url, out b);
    if (b)
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(page);
        var title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
        var imgUrl = doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']").Attributes["content"].Value;
        var mainText = doc.DocumentNode.SelectSingleNode("//div[@id='readInner']").InnerText;
    }
