    using (var context = new Context())
    {
        var book = new Book();
        book.Name = "Service Design Patterns";
        book.Publisher = new Publisher() {Id = 2 }; // Only ID is required
        context.Entry(book.Publisher).State = EntityState.Unchanged;
        context.Books.Add(book);
        context.SaveChanges();
    }
 
