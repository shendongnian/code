    public class Book
    {
        XElement self;
        public Book(XElement self) { this.self = self; }
    
        public Author[] Authors
        {
            get { return _Authors ?? // if _Authors is null, create it and then return it
                (_Authors = self.GetEnumerable("intel_auth", xauthor => new Author(xauthor)).ToArray()); }
        }
        Author[] _Authors;
        public string Title
        {
            get { return self.Get("title", string.Empty); }
        }
    }
