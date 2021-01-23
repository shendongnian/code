    [DataContract]
    public class FooClass
    {
        [DataMember]
        public string Property1 { get; set; }
    
        [DataMember]
        public string Property2 { get; set; }
    
        [DataMember]
        public Bars Bars { get; set; }
    }
    
    [DataContract]
    public class Bars
    {
        [DataMember]
        public List<Item> Items { get; set; }
    }
    
    [DataContract]
    public class Item
    {
        [DataMember]
        public string Sub_Property1 { get; set; }
    
        [DataMember]
        public string Sub_Property2 { get; set; }
    }
