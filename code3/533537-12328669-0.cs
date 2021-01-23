    XNamespace ns = "http://webservices.amazon.com/AWSECommerceService/2005-10-05";
    XDocument doc=XDocument.Load(response.GetResponseStream());
    
    var result= doc.Descendants(ns + "ItemAttributes").Select( p=> new 
     {
     Title=p.Element(ns+ "Title").Value,
     Price = p.Element(ns +"ListPrice").Element(ns+"FormattedPrice").Value
    });
