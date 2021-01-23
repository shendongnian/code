        var doc = XDocument.Load("XMLFile1.xml");
        var q =
            doc.Root
               .Elements()
               .Elements()
               .Where(e => e.Attribute("Day").Value == "3")
               .Select(e => new
                                {
                                    Shop = e.Parent.Name, 
                                    Money = e.Attribute("Money").Value
                                });
        foreach (var e in q)
        {
            Console.WriteLine("{0} {1}", e.Shop, e.Money);
        }
