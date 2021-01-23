    WebClient wc = new WebClient();
    var page = wc.DownloadString("http://radar.weather.gov/ridge/RadarImg/NCR/OKX/?C=M;O=D");
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(page);
    var imageLink = doc.DocumentNode.SelectNodes("//td/a[@href]")
                        .Select(a=>a.Attributes["href"].Value)
                        .OrderByDescending(a=>a)
                        .First();
