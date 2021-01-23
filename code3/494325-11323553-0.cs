    [ProtoContract]
    public class A {
        [ProtoMember(1)]
        public B Foo {get;set;}
    }
    [ProtoContract]
    public class B {
        [ProtoMember(1)]
        public List<byte[]> Bar {get;set;}
    }
