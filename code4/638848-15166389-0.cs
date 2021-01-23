    var xmlDocumentElement = xDocument.Load("xmlData.xml").Root;
                    
    var posts = xmlDocumentElement.Elements("post").Select(post => new 
    {
            Author = post.Element("author").Value.ToString(),
            Subject = post.Element("subject").Value.ToString(),
            AvailableDate = DateTime.Parse(post.Descendants("dates").FirstOrDefault().Value),
            Price = post.Elements("price").Min(price => Decimal.Parse(price.Element("cost").Value.ToString()))
    }
    );
