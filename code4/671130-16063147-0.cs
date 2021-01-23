    public class Book
    {
        public Book(string line)
        {
            this.Line = line;
        }
        public string Line { get; set; }
        public string[] Authors
        {
            get
            {
                return Line.Substring(0, Line.IndexOf("-") - 1).Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        public string Name
        {
            get
            {
                return Line.Substring(Line.IndexOf("-") + 1);
            }
        }
    }
    static void Main(string[] args)
    {
        var books = new List<Book>
        {
            new Book("author1::author2::author3 - title1"),
            new Book("author1::author2 - title2")            
        };
        var auth3books = books.Where(b => b.Authors.Contains("author3"));
    }
