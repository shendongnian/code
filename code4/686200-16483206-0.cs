    [DataContract]
    public class Identifier { … }
    [DataContract]
    public class Details { … }
    [DataContract]
    public class Person { … }
    [DataContract]
    public class Item
    {
        [DataMember]
        public Identifier ID { get; set; }
        [DataMember]
        public Details Details { get; set; }
 
        [DataMember]
        public List<Person> Persons { get; set; }
    }
