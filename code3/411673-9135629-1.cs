    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    namespace EFMappingTest
    {
        class Blog
        {
            public Blog()
            {
                Posts = new HashSet<Post>();
            }
            public int Id { get; set; }
            // other properties go here
            public ICollection<Post> Posts { get; set; }
        }
        class Post
        {
            public int Id { get; set; }
            //other properties go here
            public int FKBlogId { get; set; }
            public Blog Blog { get; set; }
        }
        class Context : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                // Block 1
                modelBuilder.Entity<Blog>()
                    .HasMany(b => b.Posts)
                    .WithRequired(p => p.Blog)
                    .HasForeignKey(p => p.FKBlogId);
                // End Block 1
                // Block 2
                modelBuilder.Entity<Post>()
                    .HasRequired(p => p.Blog)
                    .WithMany(b => b.Posts)
                    .HasForeignKey(p => p.FKBlogId);
                // End Block 2
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new Context())
                {
                    var blogs = context.Blogs
                        .Select(b => new
                        {
                            BlogId = b.Id,
                            Posts = b.Posts.Select(p => new
                            {
                                Id = p.Id
                            })
                        })
                        .ToList();
                }
            }
        }
    }
