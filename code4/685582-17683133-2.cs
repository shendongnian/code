    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    namespace EFSelfReference
    {
        public class MyEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? ParentId { get; set; }
            public MyEntity Parent { get; set; }
            public ICollection<MyEntity> Children { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<MyEntity> MyEntities { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MyEntity>()
                    .HasOptional(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentId);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer<MyContext>(
                    new DropCreateDatabaseAlways<MyContext>());
                using (var ctx = new MyContext())
                {
                    ctx.Database.Initialize(false);
                    var parent = new MyEntity { Name = "Parent",
                        Children = new List<MyEntity>() };
                    parent.Children.Add(new MyEntity { Name = "Child 1" });
                    parent.Children.Add(new MyEntity { Name = "Child 2" });
                    ctx.MyEntities.Add(parent);
                    ctx.SaveChanges();
                }
                using (var ctx = new MyContext())
                {
                    var parent = ctx.MyEntities.Include(e => e.Children)
                        .FirstOrDefault();
                    foreach (var child in parent.Children.ToList())
                        ctx.MyEntities.Remove(child);
                    ctx.MyEntities.Remove(parent);
                    ctx.SaveChanges();
                }
            }
        }
    }
