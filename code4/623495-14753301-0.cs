    [DataContract]
    public class Item
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }
    [DataContract]
    public class ItemCollection
    {
        [DataMember(Name = "veg")]
        public IEnumerable<Item> Vegetables { get; set; }
        [DataMember(Name = "non-veg")]
        public IEnumerable<Item> NonVegetables { get; set; }
    }
