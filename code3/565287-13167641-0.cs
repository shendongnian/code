    public class BaseClass
    {
        public virtual void Foo() { }
    }
    public class DerivedClass
    {
        public virtual void Foo() { }
        public void MoreFoo() { }
    }
    BaseClass instance = new DerivedClass();
    instance.MoreFoo(); // Doesn't compile
