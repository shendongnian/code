    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    namespace ConsoleApplication2
    {
        public class Initializer<T> : DropCreateDatabaseAlways<T> where T : DbContext
        {
            protected override void Seed(T context)
            {
                base.Seed(context);
                // Comment out this line and note how the count changes.
                context.Database.ExecuteSqlCommand("ALTER TABLE MyEntity ALTER COLUMN MyString nvarchar(MAX) COLLATE Latin1_General_CS_AS");
            }
        }
        [Table("MyEntity")]
        public class MyEntity
        {
            [Key]
            public virtual int MyEntityId { get; set; }
            [Required]
            public virtual string MyString { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<MyEntity> Entities
            {
                get { return this.Set<MyEntity>(); }
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                var e = modelBuilder.Entity<MyEntity>();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer(new Initializer<MyContext>());
                using (MyContext context = new MyContext())
                {
                    context.Entities.Add(new MyEntity { MyString = "aaa" });
                    context.Entities.Add(new MyEntity { MyString = "AAA" });
                    context.SaveChanges();
                }
                using (MyContext context = new MyContext())
                {
                    var caseSensitiveQuery = from e in context.Entities
                                             where e.MyString.Equals("aaa", StringComparison.Ordinal)
                                             select e;
                    var caseInsensitiveQuery = from e in context.Entities
                                               where e.MyString.Equals("aaa", StringComparison.OrdinalIgnoreCase)
                                               select e;
                    // Note how the StringComparison parameter is completely ignored.  Both EF queries are identical.
                    Console.WriteLine("Case sensitive query (count = {0}):\r\n{1}", caseSensitiveQuery.Count(), caseSensitiveQuery);
                    Console.WriteLine();
                    Console.WriteLine("Case insensitive query (count = {0}):\r\n{1}", caseInsensitiveQuery.Count(), caseInsensitiveQuery);
                }
                Console.ReadLine();
            }
        }
    }
