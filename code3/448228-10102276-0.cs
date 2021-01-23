    public class BaseClass
    {
        public virtual string Name { get { return "Adam"; } }
    }
    
    public class ChildClass : BaseClass
    {
        public override string Name { get { return "Foo"; } }
    }
