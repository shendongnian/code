    public class EvilBook : IBook
    {
        public string Name { get; set; }
    }
    IBookShelf bookShelf = new BookShelf() { Books = new List<Book>() };
    bookShelf.Books.Add(new EvilBook());
