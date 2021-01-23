    string url = "...";
               
    var client = new HttpClient();
    string xml = client.GetStringAsync(url).Result;
    var result = XDocument.Parse(xml).Descendants("type")
        .Where(e => (string) e.Attribute("id") == "17392")
        .Descendants("buy")
        .Select(e => (string) e.Element("max"))
        .FirstOrDefault();
