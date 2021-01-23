    var booksToRemove =
        xmlDoc.Descendants("Book")
              .Where(Book =>
                  (Book.Element("ID") != null && 
                  idsToRemove.Contains(Convert.ToInt32((string)Book.Element("ID").Value))))
              .ToArray();
    
    booksToRemove.Remove();
    var removedBooks = booksToRemove.Select(x => new
                                            {
                                                ID = (string)x.Element("ID"), 
                                                Name = (string)x.Element("Name")
                                            }).ToArray();
