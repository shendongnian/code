    public class House
    {
        [ForeignKey("Address")]              
        public int HouseId { get; set; }
        public virtual Address Address { get; set; }
    }
