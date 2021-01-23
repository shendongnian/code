    public class UserAddresses
    {
        [Key]
        public int UserAddressId { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
    public User
    {
        ...
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
        ...
    }
    public Address
    {
        ...
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
        ...
    }
