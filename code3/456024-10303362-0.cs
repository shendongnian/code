    XDocument xDoc = XDocument.Load(....);
    var dict = xDoc.Element("files")
        .Descendants()
        .ToDictionary(k=>k.Name,v=>v.Attributes().ToDictionary(ak=>ak.Name,av=>av.Value));
    foreach (var item in dict)
    {
        Console.WriteLine(item.Key+":");
        foreach (var attr in item.Value)
        {
            Console.WriteLine("\t"+attr.Key + "="+ attr.Value);
        }
    }
