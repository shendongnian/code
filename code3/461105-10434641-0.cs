    namespace TestWebServices
    {
        [KnownType(typeof(Person))]
        [DataContract]
        public class PersonWrapper
        {
            [DataMember]
            public Person d { get; set; }
        }
        [DataContract]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string FavoriteColor { get; set; }
            [DataMember]
            public int ID { get; set; }
        }
    }
