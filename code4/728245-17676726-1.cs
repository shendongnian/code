    public class Lead
    {
        [Key]
        public int LeadId { get; set; }
    
        public virtual Customer Customer { get; set; }
     }
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
    
        public virtual Lead Lead { get; set; }
    }
    builder.Entity<Lead>()
    .HasOptional(l => l.Customer)
    .WithOptionalPrincipal()
    .Map(k => k.MapKey("LeadId"));
    
    builder.Entity<Customer>()
    .HasOptional(c => c.Lead)
    .WithOptionalPrincipal()
    .Map(k => k.MapKey("CustomerId"));
