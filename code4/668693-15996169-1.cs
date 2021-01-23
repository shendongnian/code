    public class Content
    {
        public int Id { get; set; }
        public ICollection<ContentRelation> ContentRelations { get; set; }
    }
    
    public class ContentRelation
    {
        public int Id { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
    
    modelBuilder.Entity<Content>().
          HasMany(c => c.ContentRelations ).
          WithMany(p => p.Contents );
