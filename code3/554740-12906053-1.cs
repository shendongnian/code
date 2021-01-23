            var doc = XDocument.Load("XMLFile1.xml");
            var q =
                doc.Root
                   .Elements()
                   .Elements()
                   .Select(e => new
                                    {
                                        Day = e.Attribute("Day").Value,
                                        Shop = e.Parent.Name, 
                                        Money = e.Attribute("Money").Value
                                    })
                   .GroupBy(r => r.Day);
            foreach (var e in q)
            {
                Console.WriteLine("Day: {0}", e.Key);
                foreach (var i in e)
                {
                    Console.WriteLine("{0} {1}", i.Shop, i.Money);
                }
            }
