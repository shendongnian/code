    class Book : Base_Collection
    {
        public Book()
        {
        }
        public void Read_Book()
        {
        }
    }
    public static void Main(string[] args)
    {
        Base_Collection book = new Book();
        book.title = "The Dark Tower";
        (Book)book.Read_Book();
        ...
    }
