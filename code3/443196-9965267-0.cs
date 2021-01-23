    public partial class MyBook
    {
        public static List<MyBook> GetAllBooks()
        {
            using (myDBContext db = new myDBContext())
            {
                var books = from o in db.MyBooks
                            select o;
                return books.ToList();
            }
        }
    }
