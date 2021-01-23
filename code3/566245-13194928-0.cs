    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var teams = doc.DocumentNode.SelectNodes("//td[@width='313']")
                    .Select(td => new TeamClass
                    {
                        TeamName = td.Element("a").InnerText,
                        TeamId = HttpUtility.ParseQueryString(td.Element("a").Attributes["href"].Value)["ItemTypeID"]
                    })
                    .ToList();
