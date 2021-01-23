    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/TestWebServices.Person")]
    public class Person {
        [DataMember]
        public PersonItem d { get; set; }
    }
    [DataContract]
    public class PersonItem {
        [DataMember]
        public string __Type { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FavoriteColor { get; set; }
        [DataMember]
        public int ID { get; set; }
    }
