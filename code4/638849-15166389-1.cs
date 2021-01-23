    var xmlDocumentElement = xDocument.Load("xmlData.xml").Root;
                        
    var posts = xmlDocumentElement.Elements("post").Select(post => new 
        {
    	Author = post.Element("author").Value.ToString(),
    	Subject = post.Element("subject").Value.ToString(),
    	AvailableDate = DateTime.Parse(post.Descendants("dates").FirstOrDefault().Value),
    	Price = GetPriceFromPriceXElement(post.Elements("price").Min(price => Decimal.Parse(price.Element("cost").Value.ToString())))
        }
        );
    
    public Price GetPriceFromPriceXElement(XElement price)
    {
       return new Price
    	{ 
    		Provider = price.Element("provider").Value.ToString(),
    		Cost = price.Element("cost").Value.ToString()
    	};
    }
