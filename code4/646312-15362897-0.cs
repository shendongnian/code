    public interface ISomeValue { }
    public abstract class SomeValueBase : ISomeValue { }
    public class SomeValueImpl : SomeValueBase { }
    public interface ISomeObject { ISomeValue GetValue(); }
    public abstract class SomeObjectBase : ISomeObject
    {
        ISomeValue ISomeObject.GetValue() { return GetValue(); }
        public SomeValueBase GetValue() { return GetValueImpl(); }
        protected abstract SomeValueBase GetValueImpl();
    }
    public class SomeObjectImpl : SomeObjectBase
    {
        protected override SomeValueBase GetValueImpl() { return GetValue(); }
        public new SomeValueImpl GetValue() { return null; }
    }
