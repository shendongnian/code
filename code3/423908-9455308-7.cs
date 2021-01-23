    XDocument xdoc = XDocument.Load("http://ecs.amazonaws.com/onca/xml?AWSAccessKeyId=AKIAIAAFYAPOR6SX5GOA&AssociateTag=pragbook-20&IdType=ISBN&ItemId=9780061732324&MerchantId=All&Operation=ItemLookup&ResponseGroup=Medium&SearchIndex=Books&Service=AWSECommerceService&Timestamp=2012-02-26T20%3A18%3A37Z&Version=2011-08-01&Signature=r7yE7BQI44CqWZAiK%2FWumF3N4iutOj3re9wZtESOaKs%3D");
    XNamespace ns = XNamespace.Get("http://webservices.amazon.com/AWSECommerceService/2011-08-01");
    var foundNode = xdoc
        .Descendants(ns+"ItemAttributes")
        .Where(node => node.Element(ns+"ProductGroup").Value == "Book")
        .First();
    Console.WriteLine(foundNode.Element(ns+"ListPrice").Element(ns+"FormattedPrice").Value);
    Console.ReadLine();
