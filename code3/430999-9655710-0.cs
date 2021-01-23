    List<string> links = new List<string>();
    List<string> names = new List<string>();
    HtmlDocument doc = new HtmlDocument();
    //Load the Html
    doc.Load(new WebClient().OpenRead("http://geo.craigslist.org/iso/us"));
    //Get all Links in the div with the ID = 'list' that have an href-Attribute
    HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//div[@id='list']/a[@href]");
    //or if you have only the links already saved somewhere
    //HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//a[@href]");
    if (linkNodes != null)
    {
      foreach (HtmlNode link in linkNodes)
      {
        links.Add(link.GetAttributeValue("href", ""));
        names.Add(link.InnerText);//Get the InnerText so you don't get any Html-Tags
      }
    }
    //Write both lists to a File
    File.WriteAllText("urls.txt", string.Join(Environment.NewLine, links.ToArray()));
    File.WriteAllText("cities.txt", string.Join(Environment.NewLine, names.ToArray()));
