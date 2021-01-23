    IEnumerable<XElement> books = Root.Descendants("book");
    IList<XElement> booksToRemove = new List<XElement>(indexes.Length);
    foreach (int index in indexes)
    {
        booksToRemove.Add(books.ElementAt(index));
    }
    foreach (XElement book in booksToRemove)
    {
        book.Remove();
    }
