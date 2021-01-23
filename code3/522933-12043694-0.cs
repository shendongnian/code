    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
