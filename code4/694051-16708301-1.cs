    public class Category
    {      
        public int ID { get; set; }
        public string Name { get; set; }
      
    }
    public class BookDetail
    {
        private List<Book> books = new List<Book>();
        public int CategoryID { get; set; }        
        public List<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
            }
        }
    }
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
    }
