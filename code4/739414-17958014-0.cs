    var context = new DbContext(); // contains public DbSet<Doc> Docs { get; set; }
    foreach (var doc in context.Docs.Where(d => d.ImageContent.StartsWith("https:")))
    {
        doc.ImageContent = doc.ImageContent.Replace("https:", "http:");
    }
    context.SaveChanges();
