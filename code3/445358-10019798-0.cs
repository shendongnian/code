    public class Product
    {
        public int ProductId { get; set; }
        public virtual ICollection<DefaultPropertyValue> DefaultPropertyValues { get; set; }
    }
    public class ProductProperty 
    {
        public int ProductPropertyId { get; set; }
        public virtual ICollection<DefaultPropertyValue> DefaultPropertyValues { get; set; }
    }
    public class DefaultPropertyValue 
    {
        public int ProductId { get; set; }
        public int ProductPropertyId { get; set; }
        public Product Product { get; set; }
        public ProductProperty ProductProperty { get; set; }
    }
    ...
    modelBuilder.Entity<DefaultPropertyValue>()
        .HasKey(i => new { i.ProductId, i.ProductPropertyId });
    modelBuilder.Entity<DefaultPropertyValue>()
        .HasRequired(i => i.Product)
        .WithMany(u => u.DefaultPropertyValues)
        .HasForeignKey(i => i.ProductId)
        .WillCascadeOnDelete(false);
    modelBuilder.Entity<DefaultPropertyValue>()
        .HasRequired(i => i.ProductProperty)
        .WithMany(u => u.DefaultPropertyValues)
        .HasForeignKey(i => i.ProductPropertyId)
        .WillCascadeOnDelete(false);
