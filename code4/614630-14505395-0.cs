    public abstract class A
    { 
        public abstract void foo(D d);
    }
    public sealed class B : A
    {
        public override void foo(D d)
        {
            d.foo(this);
        }
    }
    public sealed class C : A
    {
        public override void foo(D d)
        {
            d.foo(this);
        }
    }
    public sealed class D
    {
       public void foo(B b) { [...] }
       public void foo(C c) { [...] }   
    }
