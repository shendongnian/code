    var query = from c in xdoc.Descendants("file")
                orderby c.Name
                select new
                {
                    // This gets the main elements
                    Name = c.Element("name") == null ? c.Value : c.Element("name").Value,
                };
