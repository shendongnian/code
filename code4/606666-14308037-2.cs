    using (var context = new Context())
    {
         var book = new Book();
         book.Name = "Service Design Patterns";
         book.PublisherId = 2; 
         context.Books.Add(book);
         context.SaveChanges();
    }
