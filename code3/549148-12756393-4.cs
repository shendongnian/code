    XElement doc = XElement.Load("yourXMLfile.xml");
    
    var lstBooks = doc.Elements("book").Select(x =>
        new Books
        {    
            ID = x.Attribute("id").Value,
            Name = x.Element("author").Value,
            Title = x.Element("title").Value,
            Price = x.Element("price").Value,
            PublishDate = Convert.ToDateTime(x.Element("Publish_date").Value),
            Description = x.Element("description").Value   
        }
    );
    //lstBooks now contain all the books
