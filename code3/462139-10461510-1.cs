    public class YourContext : DbContext
    {
        public DbSet<Document> Documents {get;set;}
        public DbSet<Paragraph> Paragraphs {get;set;}
        public DbSet<Section> Sections {get;set;}
    }
