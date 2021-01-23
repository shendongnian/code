    [DataContract]
    class MyClass
    {
        [DataMember(EmitDefaultValue = false)]
        public List<string> name;
        [DataMember(EmitDefaultValue = false)]
        public List<string> midname { get; set; }
    }
