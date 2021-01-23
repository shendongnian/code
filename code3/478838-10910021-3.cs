    public class Course :ViewModelBase
        {
            private List<Book> books;
    
            public Course(string coursename)
            {
                CourseName = coursename;
                Books = new List<Book>()
                {
                    new Book("JJJJ"),
                    new Book("KKKK"),
                    new Book("OOOOO")
                };
            }
    
            public List<Book> Books
            {
                get
                {
                    return books;
                }
                set
                {
                    books = value;
                    OnPropertyChanged("Books");
                }
            }
    
            public string CourseName
            {
                get;
                set;
            }
        }
