    public abstract class BaseClass
    {
        public virtual String Value { get; set; }
        public virtual bool ShouldSerializeValue () { return true ; }
    }
    public class DerivedClass:BaseClass
    {
        public override String Value { get; set; }
        public override bool ShouldSerializeValue () { return false ; }
    }
