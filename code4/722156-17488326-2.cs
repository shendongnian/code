    [DataContract]
    public class MyClass
    {
        [DataMember(Name = "for-sale")]
        public IList<Item> forSale { get; set; }
        [DataMember]
        public IList<Item> vehicles { get; set; }
        [DataMember]
        public IList<Item> rentals { get; set; }
    }
    
    [DataContract]
    public class Item
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
    }
