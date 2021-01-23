    [Table("BaseType")]
    public class BaseType
    {
        [Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Key]
        public int TenantId { get; set; }
        public int Name { get; set; }
    }
    [Table("Derived1")]
    public class DerivedType : BaseType
    {
        public int Active { get; set; }
        public int OtherTypeId { get; set; }
        public virtual OtherType NavigationProperty {get;set;}
    }
    [ComplexType]
    public class OtherType
    {
        public string MyProperty { get; set; }
    }
    public class EFCodeFirstContext : DbContext
    {
        public DbSet<BaseType> BaseTypes { get; set; }
        public DbSet<DerivedType> DerivedTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseType>().HasKey(p => new { p.Id, p.TenantId });
            base.OnModelCreating(modelBuilder);
        }
    }
 
