    using (var context = new Context())
    {
        var book = new Book();
        book.Name = "Service Design Patterns";                
        book.Publisher = new Publisher() { Id = 2 }; // Only ID is required
        context.Publishers.Attach(book.Publisher);
        context.Books.Add(book);
        context.SaveChanges();
    }
