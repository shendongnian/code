    public class Content
    {
        public int Id { get; set; }
        public ICollection<Content> OtherContents { get; set; }
    }
    
    modelBuilder.Entity<Content>().
          HasMany(c => c.OtherContents).
          WithMany();
