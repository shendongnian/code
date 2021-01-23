    [DebuggerDisplay("{Title}")]
    public class Catalog
    {
        XElement self;
        public Catalog(XElement catalog) { self = catalog; }
        public string Title { get { return self.Get("title", string.Empty); } }
        public Uri Link { get { return self.Get<Uri>("link", null); } }
        public Book[] Books
        {
            get { return _Books ?? (_Books = self.GetEnumerable("book", x => new Book(x)).ToArray()); }
        }
        Book[] _Books;
        [DebuggerDisplay("{Title} by {Author}")]
        public class Book
        {
            XElement self;
            public Book(XElement book) { self = book; }
            public string Id { get { return self.Get("id", string.Empty); } }
            public string Author { get { return self.Get("author", string.Empty); } }
            public string Title { get { return self.Get("title", string.Empty); } }
            public string Genre { get { return self.Get("genre", string.Empty); } }
            public decimal Price { get { return self.Get<decimal>("price", 0); } }
            public DateTime PublishDate { get { return self.Get("publish_date", DateTime.MinValue); } }
            public string Description { get { return self.Get("description", string.Empty); } }
        }
    }
