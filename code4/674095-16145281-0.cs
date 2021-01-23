    public class MyDbContext: DbContext
    {
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Visit> Visits { get; set; }
    }
