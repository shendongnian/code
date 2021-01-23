    private async void AddBooks()
    {
        var books = await Task.Run(() => GetBooks());
        foreach (var book in books)
        {
            _books.Add(book);
        }
    }
    private List<BooksViewModel> GetBooks()
    {
        List<BooksViewModel> books = new List<BooksViewModel>();
        for (count = 0; count < sizeOfdb; count++)
        {
            books.Add(new BooksViewModel { Book = new BooksSet { Id = count, Title = "Title" + count, Author = "Author", Publisher = "Publisher", Year = 1000, Note = "Note" } });
        }
        return books;
    }
