    public class Group
    {
        ...
        public Group()
        {
             this.News = new List<News>();
        }
        public virtual ICollection<News> News {get;set;}
    }
    public class News
    {
        ...
        public News()
        {
             this.Group = new List<Group>();
        }
        public virtual ICollection<Group> Groups {get;set;}
    }
    public class MyContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<News> News { get; set; }
    }
