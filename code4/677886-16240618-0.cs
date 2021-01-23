       public async Task LoadRecentlyRatedBooks()
    {
        RecentlyRatedBooks.Clear();
        try
        {
            var books = await App.CurrentApplication.BookRequests.GetBooksByCategory(BookListCategory.News, 10, 0);
    
            if (books != null)
            {
                foreach (var book in books)
                {
                    var bookViewModel = AddBook(book);
    
                    if (bookViewModel != null)
                    {
                        RecentlyRatedBooks.Add(bookViewModel);
                    }
                }
            }
        }
        catch(Exception ex)
        {
        }
    }
    
    public async Task<IEnumerable<Book>> GetBooksByCategory(BookListCategory category, uint limit, uint offset)
    {
        var request = CreateBookListURL(category, limit, offset);
        return client.GetResponseAsyncEx<List<Book>>(request);
    }
