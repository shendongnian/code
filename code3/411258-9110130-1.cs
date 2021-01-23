    public interface IPerson
    {
        string Name { get; set; }
        ICollection<Address> Addresses { get; }
        ICollection<OtherType> OtherTypes { get; }
    }
    
    public class OtherType { }
    public class Address { }
    
    class PersonModel : IPerson
    {
        public PersonModel()
        {
            Addresses = new List<Address>();
            OtherTypes = new List<OtherType>();
        }
    
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; private set; }
        public ICollection<OtherType> OtherTypes { get; private set; }
    }
    
    class PersonViewModel : IPerson
    {
        public PersonViewModel()
        {
            Addresses = new ObservableCollection<Address>();
            OtherTypes = new ObservableCollection<OtherType>();
        }
    
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; private set; }
        public ICollection<OtherType> OtherTypes { get; private set; }
    }
