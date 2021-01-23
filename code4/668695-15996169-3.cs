    public class Content
    {
        public int Id { get; set; }
        public ICollection<ContentLink> OtherContents { get; set; }
    }
    public class ContentLink
    {
        public int Id { get; set; }
        public Content Lhs{ get; set; }
        public Content Rhs{ get; set; }
        //other stuff
    }
    
    modelBuilder.Entity<Content>().
        HasMany(c => c.OtherContents).WithRequired(c=>c.Lhs);
    modelBuilder.Entity<ContentLink>().
        HasRequired(c => c.Rhs).WithMany();
