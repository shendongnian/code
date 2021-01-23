    public class MyEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<MyEntity> Entities { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MyContext())
            {
                if (!ctx.Entities.Any())
                {
                    ctx.Entities.Add(new MyEntity() { Date = new DateTime(2000, 1, 1) });
                    ctx.Entities.Add(new MyEntity() { Date = new DateTime(2012, 10, 1) });
                    ctx.Entities.Add(new MyEntity() { Date = new DateTime(2012, 12, 12) });
                    ctx.SaveChanges();
                }
                var q = from e in ctx.Entities
                        where e.Date > EntityFunctions.AddDays(new DateTime(2012, 10, 1), 10)
                        select e;
                foreach (var entity in q)
                {
                    Console.WriteLine("{0} {1}", entity.Id, entity.Date);
                }
            }
        }
    }
