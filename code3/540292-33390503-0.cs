    [DataContract]
    class Person
    {
        [DataMember]
        public string Name { get; set; } 
        [DataMember]
        public int? Age { get; set; } 
        [DataMember(EmitDefaultValue = false)]
        public string Role { get; set; } 
    }
