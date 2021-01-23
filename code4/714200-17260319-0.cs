    [Table("City")]
    [KnownType(typeof(Country))]
    public class City
    {
        public City()
        {
            Airports = new List<Airport>();
            LastUpdate = DateTime.Now;
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public Int32? CountryId { get; set; }
        [StringLength(50)]
        public String Name { get; set; }
        [Range(-12, 13)]
        public Int32? TimeZone { get; set; }
        public Boolean? SummerTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [NotMapped]
        public EntityState? EntityState { get; set; } // <----------- Here it is
    }
