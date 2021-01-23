    public class CustomerViewModel
    {
        public long Id { get; set; }
        public bool IsFoundingMember { get { return Id < 1000; } }
        public string Name { get; set; }
        public bool IsABaggins { get { return !string.IsNullOrWhiteSpace(Name) ? Name.EndsWith("Baggins") : false; } }
    }
    
