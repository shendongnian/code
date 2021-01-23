    [Table("Site")]
    public class Store {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [InverseProperty("store")]
        public virtual ICollection<Item> Items { get; set; }
    }
    [Table("Item")]
    public class Item {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("SiteID")]
        public int storeID { get; set; }
        [ForeignKey("storeID")]
        public Store store { get; set; }
    }
