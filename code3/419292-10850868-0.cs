    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                res = ctx.Tasks.Where(Task.ShouldUpdateExpression).ToList();
            }
        }
    }
    
    public class MyDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
    }
    
    public class Task
    {
        public int ID { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool ShouldUpdate
        {
            get
            {
                return ShouldUpdateExpression.Compile()(this);
            }
        }
    
        public static Expression<Func<Task, bool>> ShouldUpdateExpression
        {
            get
            {
                return t => t.LastUpdate < EntityFunctions.AddDays(DateTime.Now, 3);
            }
        }
    }
