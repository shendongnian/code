     HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
     doc.LoadHtml(response);
     //Sample query
     var node = doc.DocumentNode.Descendants("div")
               .Where(d => d.Attributes.Contains("id")).ToList(); 
