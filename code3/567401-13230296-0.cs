    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
    htmlDoc.LoadHtml(StrHtml);
    var tableNode = ( from node in htmlDoc.DocumentNode.Descendants()
                     where node.Name == "table"
                     select node ).FirstOrDefault();
                                     
    if ( tableNode != null ) {
        tableNode.Attributes["style"].Value = 
            tableNode.Attributes["style"].Value.Replace("880px", "550px");
    }
