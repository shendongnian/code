    public class Country
    {
        [Key]
        [Column("countryCode", TypeName = "varchar")]
        [MaxLength(10)]
        public string CountryCode { get; set; }
    }
    public class Store
    {
        [Key]
        [Column("store_id")
        public int Id { get; set; }
        [Column("country_code", TypeName = "varchar")]
        [MaxLength(10)]
        [Required]
        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }
    }
