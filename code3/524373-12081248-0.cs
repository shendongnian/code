    namespace TestInheritance
    {
        public interface IBookShelf <TBook> where TBook : IBook
        {
            long Stuff { get; set; }
            List<TBook> Books { get; set; }
        }
        public interface IBook
        {
            string Name { get; set; }
        }
        public class BookShelf : IBookShelf<Book>
        {
            public long Stuff { get; set; }
            public List<Book> Books { get; set; }
        }
        public class Book : IBook
        {
            public string Name { get; set; }
        }
    }
