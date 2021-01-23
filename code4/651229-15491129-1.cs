    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=yourConnectionstringName")
        {
        }
    }
