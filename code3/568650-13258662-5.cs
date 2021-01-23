    public class UserAddress
    {
        [Key]
        public int UserAddressId { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
    public User
    {
        ...
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        ...
    }
    public Address
    {
        ...
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        ...
    }
