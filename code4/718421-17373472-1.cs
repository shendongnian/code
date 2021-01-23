    var web = new HtmlAgilityPack.HtmlWeb();
    var doc = web.Load("http://www.unnu.com/popular-music-videos");
    var imgs = doc.DocumentNode.SelectNodes(@"//img[@src]")
                .Select(img => new
                {
                    Link = img.Attributes["src"].Value,
                    Title = img.Attributes["alt"].Value
                })
                .ToList();
