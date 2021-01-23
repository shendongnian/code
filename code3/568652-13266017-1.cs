    public class House
    {
        public int HouseId { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
