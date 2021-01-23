    [ProtoContract]
    class Person {
        [ProtoMember(1)]
        public int Id {get;set;}
        [ProtoMember(2)]
        public string Name {get;set;}
        [ProtoMember(3)]
        public Address Address {get;set;}
    }
    [ProtoContract]
    class Address {
        [ProtoMember(1)]
        public string Line1 {get;set;}
        [ProtoMember(2)]
        public string Line2 {get;set;}
    }
