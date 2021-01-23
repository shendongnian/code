    public partial class Address : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string Street { get; set; }
        public string CityName { get; set; }
        public int? PostalCode { get; set; }
        public virtual ICollection<EntityWithAddresses> EntityWithAddresses { get; set; }
    }
