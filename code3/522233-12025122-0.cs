    using (var wc = new WebClient())
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(wc.DownloadString("http://www.animenewsnetwork.com/encyclopedia/anime.php?list=A"));
        var links = doc.DocumentNode.SelectSingleNode("//div[@class='lst']")
            .Descendants("a")
            .Select(x => x.Attributes["href"].Value)
            .ToArray();
    }
