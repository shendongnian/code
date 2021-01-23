    public class Order
    {
        [Key]
        public Guid SerialNumber { get; set; }
    
        public string OrderNumber { get; set; }
    
        ...
    
        public virtual ICollection<Payment> Payments { get; set; }
    }
    
    public class Payment
    {
        [Key]
        public string SerialNumber { get; set; }
    
        // Foreign key must have the same type as primary key in the principal table
        public Guid OrderNumber { get; set; }
    
        ...
    
        public decimal Amount { get; set; }
    
        // Reverse navigation property to principal associated with foreign key
        [ForeignKey("OrderNumber")]
        public virtual Order Order { get; set; }
    }
