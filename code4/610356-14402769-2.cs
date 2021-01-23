    public class Customer
    {
    [Key, Required]
    public string Code { get; set; }
    public string Domain { get; set; }
    public virtual ICollection<Address> Addresses{ get; set; }
    public virtual Address BillToAddress { get { Addresses.Where(n=>n.Type = Address.BillingAddress)).Single(); }
    public virtual ICollection<Address> ShipToAddresses { get { Addresses.Where(n=>n.Type = Address.ShipToAddress)); }
    }
