    var xDoc = XDocument.Parse(xml); //or XDocument.Load(filename)
    var books = xDoc.Root.Elements("book")
                .Select(b => new
                {
                    Author = b.Element("author").Element("first-name").Value + " " +
                                b.Element("author").Element("last-name").Value,
                    Books = b.Descendants("book")
                                .Select(x => new 
                                {
                                    Title = x.Element("title").Value,
                                    Price = (decimal)x.Element("price"),
                                })
                                .Concat(new[] { new { Title = b.Element("title").Value, 
                                                    Price = (decimal)b.Element("price") } 
                                            })
                                .ToList()
                                     
                })
                .ToList();
    
