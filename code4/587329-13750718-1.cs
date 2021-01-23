    public class Software
    {
        public int Id { get; set; }
        public virtual List<SoftwareType> SoftwareTypes { get; set; }
        public virtual ICollection <Location> Locations { get; set; }
        public virtual List<SoftwarePublisher> Publishers { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [Required]
        [StringLength(10)]
        public string Version { get; set; }
        [Required]
        [StringLength(128)]
        public string SerialNumber { get; set; }
        [Required]
        [StringLength(3)]
        public string Platform { get; set; }
        [StringLength(1000)]
        public string Notes { get; set; }
        [Required]
        [StringLength(15)]
        public string PurchaseDate { get; set; }
        public bool Suite { get; set; }
        public string SubscriptionEndDate { get; set; }
        //[Required]
        //[StringLength(3)]
        public int SeatCount { get; set; }
    }
