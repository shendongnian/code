    // Create the object
    Book book = new Book("My first book", "Me");
    // Set weak reference
    WeakReference wr = new WeakReference(book);
    // Remove any reference to the book by making it null
    book = null;
    if (wr.IsAlive)
    {
        Console.WriteLine("Book is alive");\
        Book book2 = wr.Target as Book;
        Console.WriteLine(book2.Title);
        book2 = null;
    }
    else
        Console.WriteLine("Book is dead");
                
    // Lets see what happens after GC
    GC.Collect();
    
    // Should not be alive
    if (wr.IsAlive)
        Console.WriteLine("Book is alive");
    else
        Console.WriteLine("Book is dead");
