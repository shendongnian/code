    public interface IPerson
    {
        string Name { get; set; }
        ICollection<Address> Addresses { get; }
        ICollection<OtherType> OtherTypes { get; }
    }
    
    class PersonModel : IPerson
    {
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; private set; }
        public ICollection<OtherType> OtherTypes { get; private set; }
    }
    
    class PersonViewModel:IPerson
    {
        public string Name { get; set; }
        public ICollection<string> Addresses { get; private set; }
        public ICollection<int> OtherTypes { get; private set; }
    }
