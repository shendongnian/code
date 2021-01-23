    var query = docs.Descendants(name)
    .Select(x => new
    {
        Title = (string)x.Element(ns + "TITLE"),
        Status = (string)x.Element(ns + "STATUS"),
        PubEnd = (string)x.Element(ns + "PUB_END")
    
    })
    .OrderByDescending(x => x.PubEnd).Take(20); // Take will get the first N records.
    
    foreach (var book in query)
    {
        if (book.Status == "Published")
        {
            Response.Write(book.Title);
            Response.Write(book.Status);
            Response.Write(book.PubEnd);
        }
    }
