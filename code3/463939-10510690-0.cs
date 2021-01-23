    [ProtoContract]
    [ProtoInclude(1, typeof(DummyWrapper<int>)]
    [ProtoInclude(2, typeof(DummyWrapper<Customer>)]
    public abstract class DummyWrapper {
        public abstract Type ElementType {get;}
    }
    [ProtoContract]
    public class DummyWrapper<T> : DummyWrapper {
        [ProtoMember(1)]
        public T[] TheData {get;set;}
        public override Type ElementType {get { return typeof(T); } }
    }
