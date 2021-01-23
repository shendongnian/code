    public class Item : IValidatableObject
    {
        [Key]
        public int ID { get; set; }
        public virtual ICollection<ItemRelation> Related{ get; set; }
        public string Name { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (....)
            {
                yield return new ValidationResult("Your name SUX", new[] { "Name" });
            }
        }
    }
    public class ItemRelation
    {
       [Key]
        public int ID { get; set; }
        public int ItemAID { get; set; }
        public virtual Item ItemA { get; set; }
        public int ItemBID { get; set; }
        public virtual Item ItemB { get; set; }
    }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ItemRelation>().HasRequired(c => c.ItemA)
                                .WithMany(m => m.Related)
                                .HasForeignKey(c => c.ItemAID)
                                .WillCascadeOnDelete();
            modelBuilder.Entity<ItemRelation>().HasRequired(c => c.ItemB)
                               .WithMany()
                               .HasForeignKey(c => c.ItemBID)
                               .WillCascadeOnDelete(false);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemRelation> ItemsRelations { get; set; }
