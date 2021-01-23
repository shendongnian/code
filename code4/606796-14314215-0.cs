    [DataContract(Name = "Customer", Namespace = "http://www.contoso.com")]
    class Person
    {
        [DataMember()]
        public string FirstName;
        [DataMember]
        public string LastName;
        [DataMember()]
        public int ID;
    }
