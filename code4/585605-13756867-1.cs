    public class MyDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    using (var db = new MyDbContext())
    {
        var blue = new Category { Name = "Blue" };
        var red = new Category { Name = "Red" };
        db.Categories.Add(blue);
        db.Categories.Add(red);
        db.Comments.Add(new Comment
        {
            Text = "Hi",
            Categories = new List<Category> { blue }
        });
        db.SaveChanges();
    }
