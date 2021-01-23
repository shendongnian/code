    public interface IPerson
    {
        string Name { get; set; }
        ICollection<Address> Addresses { get; }
        ICollection<OtherType> OtherTypes { get; }
    }
    
    public class OtherType { }
    public class Address { }
