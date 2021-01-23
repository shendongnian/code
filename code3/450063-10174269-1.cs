    [ProtoContract]
    public class Foo : IGetFieldsByName {
        [ProtoMember(1)]
        public string Name {get;set;}
        [ProtoMember(2)]
        public Bar Something {get;set;}
    }
    [ProtoContract]
    public class Bar : IGetFieldsByName {
        [ProtoMember(1)]
        public int Id {get;set;}
    }
