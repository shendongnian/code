    public class Book
    {
      public int BookID { get; set; }
      //Whatever other information about the Book...
      public virtual Category Category { get; set; }
      public virtual List<Author> Authors { get; set; }
      public virtual List<BookPage> BookPages { get; set; }
    }
