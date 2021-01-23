    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MyContext())
            {
                var entity = new MyEntity();
                ctx.MyEntities.Add(entity);
                ctx.MyEntities.Remove(entity);
                ctx.SaveChanges();
            }
        }
    }
    public class MyContext : DbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }
    }
    public class MyEntity
    {
        public int Id { get; set; }
    }
