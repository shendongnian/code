    [Table("CUSTOMER_DETAIL")]
    public class CustomerDetail
    {
        [Required]
        [Column("CUSTOMER_DETAIL_ID")]
        public int Id {get; set;}
        // other fields
        [ForeignKey("Id")]
        public virtual Customer Customer {get; set;} 
    }
