    var items = from item in doc.Descendants("SUM")
                        select new
                        {                                    
                            Id = (string)item.Attribute("id"),
                            Category = (string)item.Attribute("cat"),
                            Selection = (string)item.Attribute("sel")
                        };
    
    var filtered = items.Where(i => i.Id == 1);
    // Then use these as needed
    foreach(var item in filtered)
    {
        Console.WriteLine("Cat: {0}, Sel: {1}", item.Category, item.Selection);
    }
