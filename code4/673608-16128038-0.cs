    public int GetNextRecordId()
    {
        // Cannot load all books into memory ...
        IEnumerable<Book> books = dataContext.Books.OrderBy(b => b.Id);
        int index = 0;
        foreach (var book in books)
        {
          index++;
          if (index < book.Id) return index;
        }
        return index;
    }
