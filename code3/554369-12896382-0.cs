    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<B> Bs { get; set; }
    }
    public class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Model : DbContext
    {
        public DbSet<A> As { get; set; }
        public DbSet<B> Bs { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var b = new B() { Name = "b" };
            var a1 = new A()
                {
                    Name = "a",
                    Bs = new List<B>() { new B() { Name = "b1" }, new B() { Name = "b2" } }
                };
            using (var context = new Model())
            {
                context.As.Add(a1);
                context.SaveChanges();
            }
            using (var context = new Model())
            {
                var a2 = (from a in context.As.Include(a => a.Bs)
                          where a.Name == "a"
                          select a).Single();
                Console.WriteLine(a2.Bs.Count);
            }
            Console.ReadLine();
        }
    }
