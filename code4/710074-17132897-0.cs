    XNamespace a = "http://www.w3.org/2005/Atom";
    XNamespace d = "http://schemas.microsoft.com/ado/2007/08/dataservices";
    XNamespace m = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
    XElement feed = XElement.Load(@"c:\data\contents.xml");
    var result =
        from entry in feed.Descendants(a + "entry")
        let partitionKey = entry.Element(d + "PartitionKey")
        let content = entry.Element(a + "content")
        let properties = content.Element(m + "properties")
        let title = properties.Element(d + "Title")
        select new 
        {
            Title = title,
            PartitionKey = partitionKey
        };
    
    foreach (var item in result)
    {
        Console.WriteLine("{0}, {1}", item.Value, item.PartitionKey);
    }
    Console.ReadLine();
