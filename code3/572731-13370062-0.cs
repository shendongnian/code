    public class MyContext: DbContext
    {
        public MyContext()
            : base("name=MyConnectionName")
        {
        }
    }
