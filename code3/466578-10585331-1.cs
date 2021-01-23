    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = web.Load(url);
    var travelList = new List<HtmlNode>();
    foreach (var matchingDiv in doc.DocumentNode.DescendantNodes().Where(n=>n.Name == "div" && n.Id == "myTrips"))
    {
        travelList.AddRange(matchingDiv.DescendantNodes().Where(n=> n.Name == "li"));
    }
