    public abstract class BaseClass
    {
        public virtual String Foo { get; set; }
        public virtual bool ShouldSerializeFoo () { return true ; }
    }
    public class DerivedClass:BaseClass
    {
        public override String Foo { get; set; }
        public override bool ShouldSerializeFoo () { return false ; }
    }
