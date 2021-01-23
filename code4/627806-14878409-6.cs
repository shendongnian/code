    public class MyContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<TextDocument> TextDocuments { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
    }
