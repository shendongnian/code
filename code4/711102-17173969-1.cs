    public class Parent
    {
        public virtual int Foo() { return 0; }
    }
    public class Child : Parent
    {
        public override int Foo() { return 1; }
    }
