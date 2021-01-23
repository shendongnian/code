    HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
    HtmlNode.ElementsFlags.Remove("form");
    doc.LoadHtml(aspPage);
    var elements = doc.DocumentNode.Descendants("div");  
    var pageControls = from z in elements.ChildNodes
                         where z.Attributes.Contains("runat") //server controls
                         select z.Attributes["ID"].Value;
 
