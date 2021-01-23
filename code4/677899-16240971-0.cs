    public class DatabaseContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<RatePeriod> RatePeriods { get; set; }
    }
    public class Post
    {
        public int ID { get; set; }
        public DateTime PostDate { get; set; }
    }
    public class RatePeriod
    {
        public int ID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
