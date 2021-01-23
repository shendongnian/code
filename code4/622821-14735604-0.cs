    [DataContract]
    public class Person
    {
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual Address Address { get; set; }
    }
    [DataContract]
    public class Address
    {
    }
