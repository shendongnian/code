    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string LocationName { get; set; }
        [InverseProperty("LocationToId")]
        public virtual ICollection<Rate> ToRates { get; set; }
        [InverseProperty("LocationFromId")]
        public virtual ICollection<Rate> FromRates { get; set; }
    }
