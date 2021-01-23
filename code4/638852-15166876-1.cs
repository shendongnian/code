     XDocument doc = XDocument.Load(@"XMLFile1.xml");
            var posts = doc.Root.Elements("post")
                       .Select(p =>
                                new
                                {
                                   Author = p.Element("author").Value,
                                   Price = p.Elements("price").OrderBy(a => decimal.Parse(a.Element("cost").Value)).First()
                         });
            foreach(var a in posts)
            {
                Console.WriteLine(a.Author + " " + a.Price);
            }
