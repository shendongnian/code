    [Table("CUstomerTable")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public virtual List<CustomerToPropertyMapping> PropertyIds { get; set; }
    }   
    
    [Table("CustomerToProperty")]
    public class CustomerToPropertyMapping
    {
        [Key]
        public int PropertyId { get; set; }
        [Column("Customer_ID")]
        public long CustomerId{ get; set; }
          [ForeignKey("CustomerId")]
        public Customer Customer{ get; set; } 
    }
