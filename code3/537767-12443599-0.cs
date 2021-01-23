         public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Photos = new HashSet<PhotoSource>();
            ProductFeatures = new HashSet<ProductFeature>();
        }
        // Primitives
        public string ProductName { get; set; }
        public string InternalSKU { get; set; }
        public string ModelNumber { get; set; } 
        public string Description { get; set; }
        public int QtyPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int? ReOrderLevel { get; set; }
        public string Warranty { get; set; }
        // Primitives for Disontinues
        public DateTime? DiscontinuedDate { get; set; }
        public int? DiscontinuedDisount { get; set; }
        // Primitives for Seasonal
        public int? OffSeasonDiscount { get; set; }
        public DateTime? SeasonStartDate { get; set; }
        public DateTime? SeasonEndDate { get; set; }
        public int? QtyLimitedTo { get; set; }
        // Foreign Keys
        public int SubCategoryID { get; set; }
        public int VendorId { get; set; }
        // Navigation Properties
        // Classes
        [ForeignKey("SubCategoryID")]
        public virtual SubCategory SubCategory { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
        // Collections
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PhotoSource> Photos { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
    }
