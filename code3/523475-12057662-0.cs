    string url = "http://.......";
            
    var t = new NReadability.NReadabilityWebTranscoder();
    bool b;
    string page = t.Transcode(url, out b);
    if (b)
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(page);
        var title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
        var text = doc.DocumentNode.SelectSingleNode("//div[@id='readInner']")
                      .InnerText;
    }
