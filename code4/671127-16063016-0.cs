    public class Book
    {
        public Book(string title, IList<string> authors)
        {
            Title = title;
            Authors = authors;
        }
    
        public string Title{get;private set;}
        public IList<string> Authors{get; private set;}
    }
