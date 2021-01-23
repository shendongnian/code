    public string CreateHTML(XElement sourceXML)
    {
        //make the Html Agility Pack object
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        //parse through your xml
        var products = sourceXML.Descendants("book")
            .Select(x => new
            {
                author = x.Element("author").Value,
                genre = x.Element("genre").Value,
                title = x.Element("title").Value,
                price = x.Element("price").Value,
                publishDate = x.Element("publish_date").Value,
                descrip = x.Element("description"),
            });
        
        //make and populate your table node
        HtmlNode tableNode = HtmlNode.CreateNode("<table border='1'>");
        foreach (var product in products)
        {
            tableNode.AppendChild(HtmlNode.CreateNode("<td>" + product.author + "</td>"));
            tableNode.AppendChild(HtmlNode.CreateNode("<td>" + product.genre + "</td>"));
            ....
        }
        //create the html root and append the table node
        doc.DocumentNode.AppendChild(HtmlNode.CreateNode("<html><body>"));
        doc.DocumentNode.Element("html").Element("body").AppendChild(tableNode);
        return doc.DocumentNode.InnerHtml;
    }
