    public interface IBookShelf<T> where T : IBook
    {
        long Stuff { get; set; }
        List<T> Books { get; set; }
    }
    public class BookShelf : IBookShelf<Book>
    {
        public long Stuff { get; set; }
        public List<Book> Books { get; set; }
    } 
