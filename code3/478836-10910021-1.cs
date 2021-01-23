    public class Book :ViewModelBase
        {
            private string bookname = string.Empty;
    
            public string BookName
            {
                get
                {
                    return bookname;
                }
                set
                {
                    bookname = value;
                    OnPropertyChanged("BookName");
                }
            }
    
            public Book(string bookname)
            {
                BookName = bookname;
            }
        }
