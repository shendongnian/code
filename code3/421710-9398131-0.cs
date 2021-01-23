    class Base
    {
        protected static void NonVirtualFoo(Base b)
        {
            // Whatever
        }
        public virtual void Foo()
        {
            Base.NonVirtualFoo(this);
        }
    }
    class Derived : Base
    {
        protected new static void NonVirtualFoo(Derived d)
        {
            // Whatever
        }
        public override void Foo()
        {
            Derived.NonVirtualFoo(this);
            Base.NonVirtualFoo(this);
        }
    }
