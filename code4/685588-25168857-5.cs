    using System;
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
    
    
            public void DeleteMyEntity(MyEntity entity)
            {
                var target = MyEntities
                    .Include(x => x.Children)
                    .FirstOrDefault(x => x.Id == entity.Id);
    
                RecursiveDelete(target);
    
                SaveChanges();
    
            }
    
            private void RecursiveDelete(MyEntity parent)
            {
                if (parent.Children != null)
                {
                    var children = MyEntities
                        .Include(x => x.Children)
                        .Where(x => x.ParentId == parent.Id);
    
                    foreach (var child in children)
                    {
                        RecursiveDelete(child);
                    }
                }
    
                MyEntities.Remove(parent);
            }
        }
    
        public class TestObjectGraph
        {
            public MyEntity RootEntity()
            {
                var root = new MyEntity
                {
                    Name = "Earth",
                    Children =
                        new List<MyEntity>
                        {
                            new MyEntity
                            {
                                Name = "Europe",
                                Children =
                                    new List<MyEntity>
                                    {
                                        new MyEntity {Name = "Germany"},
                                        new MyEntity
                                        {
                                            Name = "Ireland",
                                            Children =
                                                new List<MyEntity>
                                                {
                                                    new MyEntity {Name = "Dublin"},
                                                    new MyEntity {Name = "Belfast"}
                                                }
                                        }
                                    }
                            },
                            new MyEntity
                            {
                                Name = "South America",
                                Children =
                                    new List<MyEntity>
                                    {
                                        new MyEntity
                                        {
                                            Name = "Brazil",
                                            Children = new List<MyEntity>
                                            {
                                                new MyEntity {Name = "Rio de Janeiro"}
                                            }
                                        },
                                        new MyEntity {Name = "Chile"},
                                        new MyEntity {Name = "Argentina"}
                                    }
                            }
                        }
                };
    
                return root;
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
    
                    ctx.MyEntities.Add(new TestObjectGraph().RootEntity());
                    ctx.SaveChanges();
                }
    
                using (var ctx = new MyContext())
                {
                    var parent = ctx.MyEntities
                        .Include(e => e.Children)
                        .FirstOrDefault();
    
                    var deleteme = parent.Children.First();
    
                    ctx.DeleteMyEntity(deleteme);
                }
    
                Console.WriteLine("Completed....");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
