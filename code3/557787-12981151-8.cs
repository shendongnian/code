    HtmlDocument doc = new HtmlDocument();
    doc.Load(yourStream);
    var itemList = doc.DocumentNode.SelectSingleNode("//div[@id='menu']")
                      .Elements("p")
                      .Select(p => p.InnerText)
                      .ToList();
    
    foreach(var item in itemList)
    {
    Match m= Regex.Match(item,@"(?<name>[Aa]?\s*.*?)\s.*?(?<price>\$\d+).*");
        if(m.Success==true)
         {
                m.Groups["name"].Value;
                m.Groups["price"].Value;
         }
    }
