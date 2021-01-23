    public class Library
    {
        XElement self;
        public Library() { self = XElement.Load("libraryFile.xml"); }
        public Book[] Books 
        { 
            get 
            { 
                return _Books ?? 
                    (_Books = self.GetEnumerable("Rows/Row", x => new Book(x)).ToArray()); 
            } 
        }
        Book[] _Books ;
    }
    
    public class Book
    {
        XElement self;
        public Book(XElement xbook) { self = xbook; }
        public Author Author 
        { 
            get { return _Author ??
                (_Author = new Author(self.GetElement("Author")); }
        Author _Author;
    }
    
    public class Author
    {
        XElement self;
        public Author(XElement xauthor) { self = xauthor; }
        public string Name 
        { 
            get { return self.Get("Name", string.Empty); }
            set { self.Set("Name", value, false); }
        }
    }
