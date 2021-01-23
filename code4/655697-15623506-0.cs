    [Table("Section")]
    public class Section
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
    }
    [Table("List")]
    public class List
    {
        [Key]
        public virtual int Id { get; set; }
        [Required]
        [ForeignKey("Section")]
        public virtual int SectionId { get; set; }
        public virtual Section Section { get; set; }
        [Required]
        [ForeignKey("IncludedSection")]
        public virtual int IncludedSectionId { get; set; }
        public virtual Section IncludedSection { get; set; }
    }
    public class SectionContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();   
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Section> Sections { get; set; }
        public DbSet<List> Lists { get; set; }
    }
