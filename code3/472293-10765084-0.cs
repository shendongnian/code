       namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer<TestContext>(new DropCreateDatabaseAlways<TestContext>());
                var context = new TestContext();
                var child = new Child { };
                var parent = new Parent { Child = child };
                context.Parents.Add(parent);
                context.Children.Add(new Child { });
    
                context.SaveChanges();
    
                context.Parents.First().ChildId = 2;
                context.SaveChanges();
            }
        }
    
        public class Parent
        {
            public int Id { get; set; }
            public virtual int ChildId { get; set; }
            public virtual Child Child { get; set; }
        }
        public class Child
        {
            public int Id { get; set; }
        }
        public class TestContext : DbContext
        {
            public DbSet<Parent> Parents { get; set; }
            public DbSet<Child> Children { get; set; }
        }
    }
